package net.guides.springboot2.crud.controller;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import net.guides.springboot2.crud.exception.ResourceNotFoundException;
import net.guides.springboot2.crud.model.Inventary;
import net.guides.springboot2.crud.repository.InventaryRepository;

@RestController
@RequestMapping("/api/v1")
public class InventaryController {
	@Autowired
	private InventaryRepository inventaryRepository;

	@GetMapping("/inventary")
	public List<Inventary> getAllInventaries() {
		return inventaryRepository.findAll();
	}

	@GetMapping("/inventary/{id}")
	public ResponseEntity<Inventary> getProductoById(@PathVariable(value = "id") Long productiID)
			throws ResourceNotFoundException {
		Inventary inventary = inventaryRepository.findById(productiID)
				.orElseThrow(() -> new ResourceNotFoundException("Producto no existe para este id :: " + productiID));
		return ResponseEntity.ok().body(inventary);
	}

	@PostMapping("/inventary")
	public Inventary createInventary(@Valid @RequestBody Inventary inventary) {
		System.out.println(" Insertar " + inventary.getId());
		System.out.println(" Insertar " + inventary.getnombre());
		System.out.println(" Insertar " + inventary.getdescripcion());
		System.out.println(" Insertar " + inventary.getprecio());
		System.out.println(" Insertar " + inventary.getcantidad());
		System.out.println(" Insertar " + inventary.geturlimagen());
		System.out.println(" Insertar " + inventary.getnombreimagen());
		return inventaryRepository.save(inventary);
	}

	@PutMapping("/inventary/{id}")
	public ResponseEntity<Inventary> updateInventary(@PathVariable(value = "id") Long productiID,
													@Valid @RequestBody Inventary inventaryDetails) throws ResourceNotFoundException {
		Inventary inventary = inventaryRepository.findById(productiID)
				.orElseThrow(() -> new ResourceNotFoundException("Producto no existe para este id :: " + productiID));

		inventary.setId(inventaryDetails.getId());
		inventary.setnombre(inventaryDetails.getnombre());
		inventary.setdescripcion(inventaryDetails.getdescripcion());
		inventary.setprecio(inventaryDetails.getprecio());
		inventary.setcantidad(inventaryDetails.getcantidad());
		inventary.seturlimagen(inventaryDetails.geturlimagen());
		inventary.setnombreimagen(inventaryDetails.getnombreimagen());
		inventary.setcategoria(inventaryDetails.getcategoria());

		final Inventary updatedInventary = inventaryRepository.save(inventary);
		return ResponseEntity.ok(updatedInventary);
	}

	@DeleteMapping("/inventary/{id}")
	public Map<String, Boolean> deleteInventary(@PathVariable(value = "id") Long productiID)
			throws ResourceNotFoundException {
		Inventary inventary = inventaryRepository.findById(productiID)
				.orElseThrow(() -> new ResourceNotFoundException("Producto no existe para este id :: " + productiID));

		inventaryRepository.delete(inventary);
		Map<String, Boolean> response = new HashMap<>();
		response.put("deleted", Boolean.TRUE);
		return response;
	}
}
