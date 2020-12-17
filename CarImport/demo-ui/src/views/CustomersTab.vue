<template>
  <div>
    <button class="btn" v-on:click="searchCustomers">Търси</button>
    <b-table class="table" id="customersTable" striped hover bordered :items="result" :fields="fields" :current-page="currentPage">
      <template slot="top-row" slot-scope="{ fields }">
        <td v-for="field in fields" :key="field.name">
          <div v-if="field.key.toString() === 'name'">
          </div>
          <div v-else>
            <input v-model="filters[field.key]" :placeholder="field.label">
          </div>
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
    <b-pagination
      v-model="currentPage"
      pills
      :total-rows="rows"
      :per-page="perPage"
      @input="searchCustomers"
      aria-controls="customersTable">
    </b-pagination>
  </div>
</template>

<script>
import CustomersService from '../services/customers-service'

export default {
  name: 'CustomersTab.vue',
  data () {
    return {
      currentPage: 1,
      rows: '',
      perPage: 3,
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
    this.searchCustomers()
  },
  methods: {
    searchCustomers () {
      CustomersService.getCustomersPage(this.filters, this.currentPage, this.perPage).then(
        response => {
          this.result = response.data.result
          this.totalItems = response.data.totalItems
          this.rows = this.totalItems
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
