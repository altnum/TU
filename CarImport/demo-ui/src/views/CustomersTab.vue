<template>
  <div>
    <button class="btn" v-on:click="searchCustomers">Търси</button>
    <b-table striped hover bordered :items="result" :fields="fields">
      <template slot="top-row" slot-scope="{ fields }">
        <td v-for="field in fields" :key="field.id">
          <input v-model="filters[field.key]" :placeholder="field.label">
        </td>
      </template>

      <template v-slot:cell(city)="data">
        <div v-if="data.item.city">
        {{ data.item.city.name }}
        </div>
        <div v-else>
          Няма град
        </div>
      </template>
    </b-table>
  </div>
</template>

<script>
import CustomersService from '../services/customers-service'

export default {
  name: 'CustomersTab.vue',
  data () {
    return {
      result: [{ id: '', name: '', city: { id: '', name: '' } }],
      fields: [{ key: 'name', label: 'Име' }, { key: 'city', label: 'Град' }],
      filters: {
        name: '',
        city: ''
      },
      totalItems: ''
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
  },
  methods: {
    searchCustomers () {
      CustomersService.getCustomersPage(this.filters).then(
        response => {
          this.result = response.data.result
          this.totalItems = response.data.totalItems
        },
        error => {
          this.result = (error.response && error.response.data) || error.message || error.toString()
        }
      )
    }
  }
}
</script>

<style scoped>

</style>
