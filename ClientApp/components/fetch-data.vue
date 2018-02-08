<template>
    <div>
        <h1>Weather forecast</h1>

        <p>This component demonstrates fetching data from the server.</p>

        <p v-if="!comics"><em>Loading...</em></p>

        <table class="table" v-if="comics">
            <thead>
                <tr>
                    <th>title</th>
                    <th>publisher</th>
                    <th>characters</th>
                    <th>issue</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="comic in comics" >
                    <td>{{ comic.title }}</td>
                    <td>{{ comic.title }}</td>
                    <td>{{ comic.title }}</td>
                    <td>{{ comic.title }}</td>
                </tr>
            </tbody>
        </table>
        

    </div>
</template>

<script>
export default {
    data() {
        return {
            comics: null
        }
    },

    methods: {
    },

    async created() {
        try {
            let response = await this.$http.get('/api/comics/')
            console.log(response.data);
            this.comics = response.data;
        } catch (error) {
            console.log(error)
        }

    }
}
</script>

<style>
</style>
