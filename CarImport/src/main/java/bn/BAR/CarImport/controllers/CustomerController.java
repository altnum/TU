package bn.BAR.CarImport.controllers;

import bn.BAR.CarImport.Entities.Customers;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import bn.BAR.CarImport.repositories.CustomersRepository;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
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
        return customersRepository.findById(id == null ? 3L : id);
    }

    @DeleteMapping("/delete")
    public ResponseEntity<?> deleteCustomer(@RequestParam Long id) {
        if (id == null) return ResponseEntity.badRequest().body("Не сте въвели ID!");
        customersRepository.findById(id).ifPresent(customer -> customersRepository.delete(customer));
        return ResponseEntity.ok("Успешно изтрит!");
    }

    @PostMapping("/save")
    public ResponseEntity<?> saveOrUpdateCustomer(@RequestParam(required = false) Long id, @RequestParam(required = false) String name) {
        Customers customer = new Customers(id, name);
        customer = customersRepository.save(customer);
        Map<String, Object> response = new HashMap<>();
        response.put("Генерирано ID:", customer.getId());
        response.put("message", "Успешно записан!");

        return new ResponseEntity<>(response, HttpStatus.OK);

    }

    @GetMapping("/search/name")
        public ResponseEntity<?> getCustomersByName(@RequestParam(required = false) String name) {
        if(name == null || name.isBlank()) {
            return ResponseEntity.badRequest().body("Не сте подали име като критерий за търсене");
        }
        Customers result = customersRepository.findByName(name.toLowerCase());
        return result == null ? ResponseEntity.ok("Няма намерен потребител спрямо зададените критерии") : ResponseEntity.ok(result);
    }

}
