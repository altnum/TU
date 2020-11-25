<template>
  <div>
    <header class="jumbotron">
      <h1>{{result}}</h1>
    </header>
  </div>
</template>

<script>
import CustomersService from '../services/customers-service'

export default {
  name: 'CustomersTab.vue',
  data () {
    return {
      result: ''
    }
  },
  mounted () {
    CustomersService.getAllCustomers().then(
      response => {
        this.result = response.data
      },
      error => {
        this.result = (error.response && error.response.data) || error.message || error.toString()
      }
    )
  }
}
</script>

<style scoped>

</style>
