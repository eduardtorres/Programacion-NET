package pica.springboot.inventary.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "inventary")
public class Inventary1 {

	private long id;
	private String nombre;
	private String descripcion;
	private Double precio;
//	private int cantidad;
	private String urlimagen;
	private String nombreimagen;
	private String categoria;

	public Inventary1() {
		super();
	}

	@Override
	public int hashCode() {
		return super.hashCode();
	}

	@Override
	public boolean equals(Object obj) {
		return super.equals(obj);
	}

	@Override
	protected Object clone() throws CloneNotSupportedException {
		return super.clone();
	}

	@Override
	protected void finalize() throws Throwable {
		super.finalize();
	}
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	public long getId() {
		return id;
	}
	public void setId(long id) {
		this.id = id;
	}

	@Column(name = "nombre", nullable = false)
	public String getnombre() {
		return nombre;
	}
	public void setnombre(String nombre) {
		this.nombre = nombre;
	}

	@Column(name = "descripcion", nullable = false)
	public String getdescripcion() {
		return descripcion;
	}

	public void setdescripcion(String descripcion) {
		this.descripcion = descripcion;
	}

	@Column(name = "precio", nullable = false)
	public Double getprecio() {
		return precio;
	}

	public void setprecio(Double precio) {
		this.precio = precio;
	}
//	@Column(name = "cantidad", nullable = false)
//	public int getcantidad() {
//		return cantidad;
//	}

//	public void setcantidad(int cantidad) {
//		this.cantidad = cantidad;
//	}
	@Column(name = "urlimagen", nullable = false)
	public String geturlimagen() {
		return urlimagen;
	}

	public void seturlimagen(String urlimagen) {
		this.urlimagen = urlimagen;
	}
	@Column(name = "nombreimagen", nullable = false)
	public String getnombreimagen() {
		return nombreimagen;
	}

	public void setnombreimagen(String nombreimagen) {
		this.nombreimagen = nombreimagen;
	}
	@Column(name = "categoria", nullable = false)
	public String getcategoria() {
		return categoria;
	}

	public void setcategoria(String categoria) {
		this.categoria = categoria;
	}

	public Inventary1(long id, String nombre, String descripcion, Double precio, int cantidad, String urlimagen, String nombreimagen, String categoria) {
		this.id = id;
		this.nombre = nombre;
		this.descripcion = descripcion;
		this.precio = precio;
		//this.cantidad = cantidad;
		this.urlimagen = urlimagen;
		this.nombreimagen = nombreimagen;
		this.categoria = categoria;
	}

	@Override
	public String toString() {
		return super.toString();
	}
}
