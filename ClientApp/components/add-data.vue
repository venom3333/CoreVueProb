<template>
    <div>
        <h1>Добавление данных</h1>
        <button @click="addData()">Добавить данные...</button>
        <label>Имя<input v-model="firstName" class="form-control" type="text" name="firstName" value="" /></label>
        <label>Фамилия<input v-model="lastName" class="form-control" type="text" name="lastName" value="" /></label>
        <label>Возраст<input v-model="age" class="form-control" type="number" name="age" value="" /></label>
        <label>
            Категории
            <select v-model="selectedCategories" class="form-control" name="myDataCategory" multiple value="">
                <option v-for="category in categories" :value="category.id">
                    {{category.categoryName}}
                </option>
            </select>
        </label>
        <p v-if="isValid">Данные сохранены!</p>
        <p v-if="showError">Ошибка данных!</p>
    </div>
</template>
<script>
    export default {
        data() {
            return {
                firstName: '',
                lastName: '',
                age: 18,
                selectedCategories: [],
                categories: [],

                isValid: false,
                showError: false
            }
        },

        methods: {
            addData: async function () {
                try {

                    let selectedCategoriesId = [];
                    this.selectedCategories.forEach(function (item, i, arr) {
                        selectedCategoriesId.push({ "CategoryId": item });
                    });

                    let response = await this.$http.post('/api/SampleData/AddMyData',
                        {
                            "FirstName": this.firstName,
                            "LastName": this.lastName,
                            "Age": this.age,
                            "MyDataCategory": selectedCategoriesId
                        },
                        {
                            headers: {
                                'Content-Type': 'application/json'
                            }
                        })

                    console.log(response.data);
                    if (response.data === true) {
                        this.isValid = true;
                        this.showError = false;
                    }
                    else {
                        this.isValid = false;
                        this.showError = true;
                    }
                    //this.myData = response.data;
                } catch (error) {
                    console.log(error)
                }
            },

            getCategories: async function () {
                try {
                    let response = await this.$http.post('/api/SampleData/GetCategories')
                    console.log(response.data);
                    return response.data;
                } catch (error) {
                    console.log(error)
                }
            },
        },

        async created() {
            this.categories = await this.getCategories();
        }
    }
</script>
<style>
</style>
