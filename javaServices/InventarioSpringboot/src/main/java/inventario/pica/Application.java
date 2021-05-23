package inventario.pica;

import inventario.pica.controller.InventaryController;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.web.servlet.support.SpringBootServletInitializer;
import org.springframework.context.annotation.Import;
import org.springframework.data.jpa.repository.config.EnableJpaAuditing;

@SpringBootApplication
@Import({ InventaryController.class })
@EnableJpaAuditing
public class Application extends SpringBootServletInitializer {
	// silence console logging
	@Value("${logging.level.root:OFF}")
	String message = "";

	public static void main(String[] args) {
		SpringApplication.run(Application.class, args);
	}
}
