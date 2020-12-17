package bn.BAR.CarImport.controllers;

import bn.BAR.CarImport.Entities.City;
import bn.BAR.CarImport.Entities.Customers;
import bn.BAR.CarImport.repositories.CityRepository;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import bn.BAR.CarImport.repositories.CustomersRepository;

import java.util.*;

@CrossOrigin(origins = "*", maxAge = 3600)
@RestController
@RequestMapping("/customers")
public class CustomerController {

    private CustomersRepository customersRepository;
    private CityRepository cityRepository;

    public CustomerController(CustomersRepository customersRepository, CityRepository cityRepository) {
        this.customersRepository = customersRepository;
        this.cityRepository = cityRepository;
    }

    @GetMapping("/all")
        public List<Customers> getCustomers() {
        return customersRepository.findAll();
    }

    @GetMapping("/search/id")
        public Optional<Customers> getCustomersByID(@RequestParam(required = false) Long id) {
        return customersRepository.findById(id == null ? 3L : id);
    }

   /* @GetMapping("/search/name")
    public ResponseEntity<?> getCustomersByName(@RequestParam(required = false) String name) {
        if(name == null || name.isBlank()) {
            return ResponseEntity.badRequest().body("Не сте подали име като критерий за търсене");
        }
        Optional<Customers> result = customersRepository.findByName(name.toLowerCase());
        return result.isPresent() ? ResponseEntity.ok(result.get()) : ResponseEntity.ok("Няма намерен потребител спрямо зададените критерии");
    }

    */

    @DeleteMapping("/delete")
    public ResponseEntity<?> deleteCustomer(@RequestParam Long id) {
        if (id == null) return ResponseEntity.badRequest().body("Не сте въвели ID!");
        else if (!customersRepository.existsById(id)){
            return ResponseEntity.ok("Няма такъв човек!");
        }
        customersRepository.deleteById(id);
        return ResponseEntity.ok("Успешно изтрит!");
    }

    @PostMapping("/save")
    public ResponseEntity<?> saveOrUpdateCustomer(@RequestParam(required = false) Long id, @RequestParam(required = false) String name, @RequestParam(required = false) String cityName) {
        boolean isNew = id == null;

        City city = cityRepository.findCityByName(cityName.toLowerCase());
        Customers customer = new Customers(id, name);

        customer.setCity(city);
        customer = customersRepository.save(customer);

        Map<String, Object> response = new HashMap<>();
        
        response.put("Генерирано ID:", customer.getId());

        if (isNew) {
            response.put("message", "Успешно записан!");
        } else {
            response.put("message", "Успешно редактиран!");
        }

        return new ResponseEntity<>(response, HttpStatus.OK);
    }

    @GetMapping("/search/pages")
    public ResponseEntity<?> paginateCustomers
            (@RequestParam(value = "currentPage", defaultValue = "1") int currentPage,
             @RequestParam(value = "perPage", defaultValue =  "3") int perPage,
             @RequestParam(required = false) String name,
             @RequestParam(required = false) String city) {

        Pageable pageable = PageRequest.of(currentPage -1, perPage);
        Page<Customers> customers = customersRepository.findPageCustomers(pageable, name.toLowerCase(), city.toLowerCase());

        Map<String, Object> response = new HashMap<>();
        response.put("result", customers.getContent());
        response.put("currentPage", customers.getNumber());
        response.put("totalItems", customers.getTotalElements());
        response.put("totalPages", customers.getTotalPages());

        return new ResponseEntity<>(response, HttpStatus.OK);
    }
}
