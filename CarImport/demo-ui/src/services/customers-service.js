import axios from 'axios'

const API_URL = 'http://localhost:8080/customers'

class CustomersService {
  getAllCustomers () {
    return axios.get(API_URL + '/all')
  }

  getCustomersPage (filters, currentPage, perPage) {
    return axios.get(API_URL + '/search/pages', { params: { currentPage: currentPage, perPage: perPage, name: filters.name, city: filters.city } })
  }
}

export default new CustomersService()
