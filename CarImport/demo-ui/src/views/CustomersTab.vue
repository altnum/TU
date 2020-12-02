<template>
  <div>
    <header class="jumbotron">
        <div v-for="(item, index) in result" :key="item.id">
          <header><h3>Customer №{{index}}</h3></header>
          Име: {{ item.name }}
          <div v-if="item.city">
            <h4>Град: </h4>{{ item.city.name }}
          </div>
          <div v-else>
              <h4>Град: </h4>Не е въведен.
          </div>
          <hr>
      </div>
    </header>
  </div>
</template>

<script>
import CustomersService from '../services/customers-service'

export default {
  name: 'CustomersTab.vue',
  data () {
    return {
      result: [{ id: '', name: '', city: { id: '', name: '' } }]
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
