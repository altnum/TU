import axios from 'axios'

const API_URL = 'http://localhost:8080/customers'

class CustomersService {
  getAllCustomers () {
    return axios.get(API_URL + '/all')
  }
}

export default new CustomersService()
