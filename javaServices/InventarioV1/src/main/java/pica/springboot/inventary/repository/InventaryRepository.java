package pica.springboot.inventary.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import pica.springboot.inventary.model.Inventary;

import java.util.List;

@Repository
public interface InventaryRepository extends JpaRepository<Inventary, Long>{

/*  @Query(value="select id as Id,codigo as Codigo,fabricante as Fabricante,tipoproveedor as TipoProveedor,codigoProveedor as CodigoProveedor,nombre as Nombre,descripcion as Descripcion,categoria as Categoria,precio as Precio,inventario as Inventariofrom inventario where nombre LIKE ?1%",nativeQuery=true)
        public List<Inventary> findnombre(String nombre);

    @Query("SELECT m FROM Movie m WHERE m.rating LIKE ?1%")
    List<Movie> searchByRatingStartsWith(String rating);*/
}
