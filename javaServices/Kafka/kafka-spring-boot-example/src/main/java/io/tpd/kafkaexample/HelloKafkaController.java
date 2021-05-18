package io.tpd.kafkaexample;

import org.apache.kafka.clients.consumer.ConsumerRecord;
import org.apache.kafka.common.header.Headers;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.kafka.annotation.KafkaListener;
import org.springframework.kafka.core.KafkaTemplate;
import org.springframework.messaging.handler.annotation.Payload;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.TimeUnit;
import java.util.stream.IntStream;
import java.util.stream.StreamSupport;

@RestController
public class HelloKafkaController {

    private static final Logger logger =
            LoggerFactory.getLogger(HelloKafkaController.class);

    private final KafkaTemplate<String, Object> template;
    private final String topicName;
    private final int messagesPerRequest;
    private CountDownLatch latch;

    public HelloKafkaController(
            final KafkaTemplate<String, Object> template,
            @Value("${tpd.topic-name}") final String topicName,
            @Value("${tpd.messages-per-request}") final int messagesPerRequest) {
        this.template = template;
        this.topicName = topicName;
        this.messagesPerRequest = messagesPerRequest;
    }

    @GetMapping("/hello")
    public String hello() throws Exception {
        latch = new CountDownLatch(messagesPerRequest);
        //fecha
        Date date = new Date();
        DateFormat hourFormat = new SimpleDateFormat("HH:mm:ss");
        DateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
        System.out.println("Hora: " + hourFormat.format(date));
        System.out.println("Fecha: " + hourFormat.format(date));
        //fechafin

        IntStream.range(0, messagesPerRequest)

                .forEach(i -> this.template.send(topicName, String.valueOf(i),
                        new CotizacionTransporte("Cotizacion transporte", i,1053333333,11001,05001,11,71, date))
                );
        //comentar cuando termine pruebas
        latch.await(60, TimeUnit.SECONDS);
        logger.info("All messages received");
        return "Hello Kafka!";
    }

    @KafkaListener(topics = "cotizacion-transportador", clientIdPrefix = "json",
            containerFactory = "kafkaListenerContainerFactory")
    public void listenAsObject(ConsumerRecord<String, CotizacionTransporte> cr,
                               @Payload CotizacionTransporte payload) {
        logger.info("Logger 1 [JSON] received key {}: Type [{}] | Payload: {} | Record: {}", cr.key(),
                typeIdHeader(cr.headers()), payload, cr.toString());
        latch.countDown();
    }

    private static String typeIdHeader(Headers headers) {
        return StreamSupport.stream(headers.spliterator(), false)
                .filter(header -> header.key().equals("__TypeId__"))
                .findFirst().map(header -> new String(header.value())).orElse("N/A");
    }
}
