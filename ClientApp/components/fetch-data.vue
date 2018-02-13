<template>
    <div>
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        <p v-if="!myData"><em>Loading...</em></p>
        <button @click="fetchData()">Получить данные...</button>
        <table class="table" v-if="myData !== null && myData.length > 1">
            <thead>
                <tr>
                    <th v-for="(value, key, index) in myData[0]">{{ key }}</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="dataItem in myData">
                    <td v-for="data in dataItem">
                        <template v-if="Array.isArray(data)">
                            {{ data.join(', ') }}
                        </template>
                        <template v-else>
                            {{ data }}
                        </template>
                    </td>
                </tr>
            </tbody>
        </table>

    </div>
</template>
<script>
    export default {
        data() {
            return {
                myData: null
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
            }
        },

        async created() {
            // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
            // TypeScript can also transpile async/await down to ES5
            try {
                let response = await this.$http.get('/api/SampleData/WeatherForecasts')
                console.log(response.data);
                this.myData = response.data;
            } catch (error) {
                console.log(error)
            }
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
