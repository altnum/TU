package bn.BAR.CarImport;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.web.servlet.support.SpringBootServletInitializer;

@SpringBootApplication(scanBasePackages={"bn.BAR.CarImport.controllers", "bn.BAR.CarImport.Entities", "bn.BAR.CarImport.repositories"})
public class CarImportApplication extends SpringBootServletInitializer {

	public static void main(String[] args) {
		SpringApplication.run(CarImportApplication.class, args);
	}

}
