package bn.BAR.CarImport.repositories;

import bn.BAR.CarImport.Entities.City;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

public interface CityRepository extends JpaRepository<City, Long> {
    @Query("SELECT c FROM City c WHERE lower(c.name) = :cityName")
    City findCityByName(String cityName);
}
