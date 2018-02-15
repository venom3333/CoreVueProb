<template>
    <div>
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        <p v-if="!myData"><em>Loading...</em></p>
        <template v-if="myData && myData.length > 0">
            <button @click="fetchData()" class="btn btn-primary">Получить данные...</button>
            <p v-if="showError">Ошибка при удалении!</p>
            <table class="table" v-if="myData !== null && myData.length > 0">
                <thead>
                    <tr>
                        <th v-for="(value, key, index) in myData[0]">{{ key }}</th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="dataItem in myData">
                        <td v-for="data in dataItem">
                            <template v-if="Array.isArray(data)">
                                <template v-for="item in data">
                                    {{ item.category.categoryName }}
                                    <br>
                                </template>
                            </template>
                            <template v-else>
                                {{ data }}
                            </template>
                        </td>
                        <td>
                            <router-link class="btn btn-danger" :to="{ path: '/add-data/' + dataItem.id }">
                                Редактировать..
                            </router-link>
                        </td>
                        <td><button @click="deleteData(dataItem.id)" class="btn btn-danger">Удалить..</button></td>
                    </tr>
                </tbody>
            </table>
        </template>
        <template v-else>
            Данных нет.
        </template>
    </div>
</template>
<script>
    export default {
        data() {
            return {
                myData: null,
                showError: false
            }
        },

        methods: {
            fetchData: async function () {
                try {
                    let response = await this.$http.get('/api/SampleData/MyData')
                    console.log(response.data);
                    this.myData = response.data;
                } catch (error) {
                    console.log(error)
                }
            },

            deleteData: async function (id) {
                try {
                    let response = await this.$http.post(
                        '/api/SampleData/DeleteMyData',
                        {
                            "id": id
                        },
                        {
                            headers: {
                                'Content-Type': 'application/json'
                            }
                        }
                    );
                    console.log(response.data);
                    if (response.data === true) {
                        this.showError = false;
                        this.myData = this.myData.filter(obj => obj.id != id);
                    } else {
                        this.showError = true;
                    }
                } catch (error) {
                    console.log(error)
                }
            }
        },

        async created() {

            this.fetchData();

            // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
            // TypeScript can also transpile async/await down to ES5
            //try {
            //    let response = await this.$http.get('/api/SampleData/WeatherForecasts')
            //    console.log(response.data);
            //    this.myData = response.data;
            //} catch (error) {
            //    console.log(error)
            //}
            // Old promise-based approach
            //this.$http
            //    .get('/api/SampleData/WeatherForecasts')
            //    .then(response => {
            //        console.log(response.data)
            //        this.forecasts = response.data
            //    })
            //    .catch((error) => console.log(error))*/
        }
    }
</script>
<style>
</style>
