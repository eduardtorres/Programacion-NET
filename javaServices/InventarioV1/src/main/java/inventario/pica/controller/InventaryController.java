package inventario.pica.controller;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import inventario.pica.exception.ResourceNotFoundException;
import inventario.pica.model.Inventary;
import inventario.pica.repository.InventaryRepository;

@RestController
@RequestMapping("/Inventary")
public class InventaryController {
	private ArrayList<Inventary> listaOrden = null;
	@Autowired
	private InventaryRepository inventaryRepository;

/*	@GetMapping(value = "/inventary={nombre}", produces = "application/json")
	public ResponseEntity<List<Inventary>> obtenerProdNombre(@PathVariable String nombre)
	{
		System.out.println("Select"+ nombre);
		List<Inventary> resultado = inventaryRepository.findnombre(nombre);
		//return new ResponseEntity<List<Inventary>>(resultado, HttpStatus.OK);
		return ResponseEntity.ok().body(resultado);
	}*/
@GetMapping("/inventario")
public List<Inventary> getAllInventaries() {
	return inventaryRepository.findAll();
}

	@GetMapping("/inventario/{id}")
	public ResponseEntity<Inventary> getProductoById(@PathVariable(value = "id") Long productiID)
			throws ResourceNotFoundException {
		Inventary inventary = inventaryRepository.findById(productiID)
				.orElseThrow(() -> new ResourceNotFoundException("Producto no existe para este id :: " + productiID));
		return ResponseEntity.ok().body(inventary);
	}

	@GetMapping("/inventario/")
	public ResponseEntity<Inventary> getProductoBycodigo(@RequestParam(value = "codigo") Long productcodigo)
			throws ResourceNotFoundException {

		Inventary inventary = inventaryRepository.findById(productcodigo)
				.orElseThrow(() -> new ResourceNotFoundException("Producto no existe para este id :: " + productcodigo));
		return ResponseEntity.ok().body(inventary);
	}

	@PostMapping("/producto")
	public Inventary createInventary(@Valid @RequestBody Inventary inventary) {
		System.out.println(" Insertar " + inventary.getId());
		System.out.println(" Insertar " + inventary.getNombre());
		System.out.println(" Insertar " + inventary.getNombre());
		return inventaryRepository.save(inventary);
			}

	@PutMapping("/descargar/{id}")
	public ResponseEntity<Inventary> updateInventary(@PathVariable(value = "id") Long productiID,
													@Valid @RequestBody Inventary inventaryDetails) throws ResourceNotFoundException {
		Inventary inventary = inventaryRepository.findById(productiID)
				.orElseThrow(() -> new ResourceNotFoundException("Producto no existe para este Id :: " + productiID));

		inventary.setId(inventaryDetails.getId());
		inventary.setCodigo(inventaryDetails.getCodigo());
		inventary.setCodigoproveedor(inventaryDetails.getCodigoproveedor());
		inventary.setDescripcion(inventaryDetails.getDescripcion());
		inventary.setDisponibilidad(inventaryDetails.getDisponibilidad());
		inventary.setFabricante(inventaryDetails.getFabricante());
		inventary.setMoneda(inventaryDetails.getMoneda());
		inventary.setNombre(inventaryDetails.getNombre());
		inventary.setPrecio(inventaryDetails.getPrecio());
		inventary.setInventario(inventaryDetails.getInventario());
		inventary.setCategoria(inventaryDetails.getCategoria());
		inventary.setUrlimagen(inventaryDetails.getUrlimagen());
		inventary.setNombreimagen(inventaryDetails.getNombreimagen());
		inventary.setTipoproveedor(inventaryDetails.getTipoproveedor());
		final Inventary updatedInventary = inventaryRepository.save(inventary);
		return ResponseEntity.ok(updatedInventary);
	}

	@DeleteMapping("/descargar/{id}")
	public Map<String, Boolean> deleteInventary(@PathVariable(value = "Id") Long productiID)
			throws ResourceNotFoundException {
		Inventary inventary = inventaryRepository.findById(productiID)
				.orElseThrow(() -> new ResourceNotFoundException("Producto no existe para este id :: " + productiID));

		inventaryRepository.delete(inventary);
		Map<String, Boolean> response = new HashMap<>();
		response.put("deleted", Boolean.TRUE);
		return response;
	}
}
