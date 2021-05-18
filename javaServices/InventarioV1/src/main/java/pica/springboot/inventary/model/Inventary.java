package pica.springboot.inventary.model;

import javax.persistence.*;

@Entity
@Table(name = "inventario")
public class Inventary {
    private long id;
    private String codigo;
    private String codigoproveedor;
    private String descripcion;
    private String disponibilidad;
    private String fabricante;
    private String moneda;
    private String nombre;
    private Double precio;
    private int inventario;
    private String categoria;
    private String urlimagen;
    private String nombreimagen;
    private String tipoproveedor;

    public Inventary() {
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

    @Column(name = "codigo", nullable = false)
    public String getCodigo() {
        return codigo;
    }

    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

     @Column(name = "descripcion", nullable = false)
    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }
    @Column(name = "disponibilidad", nullable = false)
    public String getDisponibilidad() {
        return disponibilidad;
    }

    public void setDisponibilidad(String disponibilidad) {
        this.disponibilidad = disponibilidad;
    }

    @Column(name = "fabricante", nullable = false)
    public String getFabricante() {
        return fabricante;
    }

    public void setFabricante(String fabricante) {
        this.fabricante = fabricante;
    }
    @Column(name = "moneda", nullable = false)
    public String getMoneda() {
        return moneda;
    }

    public void setMoneda(String moneda) {
        this.moneda = moneda;
    }

    @Column(name = "nombre", nullable = false)
    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    @Column(name = "precio", nullable = false)
    public Double getPrecio() {
        return precio;
    }

    public void setPrecio(Double precio) {
        this.precio = precio;
    }

    @Column(name = "inventario", nullable = false)
    public int getInventario() {
        return inventario;
    }

    public void setInventario(int inventario) {
        this.inventario = inventario;
    }

    @Column(name = "categoria", nullable = false)
    public String getCategoria() {  return categoria;    }

    public void setCategoria(String categoria) { this.categoria = categoria;  }

    @Column(name = "urlimagen", nullable = false)
    public String getUrlimagen() {
        return urlimagen;
    }

    public void setUrlimagen(String urlimagen) {
        this.urlimagen = urlimagen;
    }
    @Column(name = "nombreimagen", nullable = false)
    public String getNombreimagen() {
        return nombreimagen;
    }

    public void setNombreimagen(String nombreimagen) {
        this.nombreimagen = nombreimagen;
    }
    @Column(name = "tipoproveedor", nullable = false)
    public String getTipoproveedor() {
        return tipoproveedor;
    }

    public void setTipoproveedor(String tipoproveedor) {
        this.tipoproveedor = tipoproveedor;
    }
    @Column(name = "codigoproveedor", nullable = false)
    public String getCodigoproveedor() {
        return codigoproveedor;
    }

    public void setCodigoproveedor(String codigoproveedor) {
        this.codigoproveedor = codigoproveedor;
    }

    public Inventary(long id, String codigo, String codigoproveedor, String descripcion, String disponibilidad, String fabricante, String moneda, String nombre, Double precio, int inventario, String categoria, String urlimagen, String nombreimagen, String tipoproveedor) {
        this.id = id;
        this.codigo = codigo;
        this.codigoproveedor = codigoproveedor;
        this.descripcion = descripcion;
        this.disponibilidad = disponibilidad;
        this.fabricante = fabricante;
        this.moneda = moneda;
        this.nombre = nombre;
        this.precio = precio;
        this.inventario = inventario;
        this.categoria = categoria;
        this.urlimagen = urlimagen;
        this.nombreimagen = nombreimagen;
        this.tipoproveedor = tipoproveedor;
    }

    @Override
    public String toString() {
        return super.toString();
    }
}
