package bn.BAR.CarImport.repositories;

import bn.BAR.CarImport.Entities.Customers;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface CustomersRepository extends JpaRepository<Customers, Long> {
    @Query("SELECT c FROM Customers c "+
            "LEFT JOIN c.city city WHERE lower(c.name) LIKE :#{#name == null || #name.isEmpty()? '%' : '%'+#name+'%'} " +
            "AND lower(city.name) LIKE :#{#city == null || #city.isEmpty()? '%' : '%'+#city+'%'}")
    Page<Customers> findPageCustomers(Pageable page, String name, String city);
}
