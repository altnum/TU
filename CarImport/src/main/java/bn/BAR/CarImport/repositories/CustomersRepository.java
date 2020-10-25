package bn.BAR.CarImport.repositories;

import bn.BAR.CarImport.Entities.Customers;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

public interface CustomersRepository extends JpaRepository<Customers, Long> {

    @Query("SELECT c FROM Customers c WHERE lower(c.name) = :name")
    Customers findByName(String name);
}
