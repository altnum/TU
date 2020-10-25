package bn.BAR.CarImport.controllers;

import bn.BAR.CarImport.Entities.Customers;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import bn.BAR.CarImport.repositories.CustomersRepository;

import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/customers")
public class CustomerController {

    @Autowired
    CustomersRepository customersRepository;

    @GetMapping("/all")
        public List<Customers> getCustomers() {
        return customersRepository.findAll();
    }

    @GetMapping("/search/id")
        public Optional<Customers> getCustomersByID(@RequestParam(required = false) Long id) {
        return customersRepository.findById(id == null ? 2L : id);
    }

    @GetMapping("/search/name")
        public Customers getCustomersByName(@RequestParam String name) { return customersRepository.findByName(name.toLowerCase()); }

}
