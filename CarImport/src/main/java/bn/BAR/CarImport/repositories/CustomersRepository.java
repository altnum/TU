package bn.BAR.CarImport.repositories;

import bn.BAR.CarImport.Entities.Customers;
import org.springframework.data.jpa.repository.JpaRepository;

public interface CustomersRepository extends JpaRepository<Customers, Long> {
}
