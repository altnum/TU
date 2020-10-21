package bn.BAR.CarImport.controllers;

import bn.BAR.CarImport.Entities.Customers;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import bn.BAR.CarImport.repositories.CustomersRepository;

import java.util.List;

@RestController
@RequestMapping("/customers")
public class CustomerController {

    @Autowired
    CustomersRepository customersRepository;

    @GetMapping("/all")
        public List<Customers> getCustomers() {
        return customersRepository.findAll();
    }
}
