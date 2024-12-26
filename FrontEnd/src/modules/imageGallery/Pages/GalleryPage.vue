<template>
    <h1>Galeria</h1>

    <body>
        <div>
            <div v-if="loading">Wczytywanie Obrazów</div>
            <div v-if="error" class="error">{{ error }}</div>
            <ul v-if="images.length">
                <li v-for="image in images" :key="image.id">
                    <img v-if="image.fileName !== null" :src="image.fileName" alt="Image" class="image" />
                    <!-- use bootstrap tiles -->
                </li>
            </ul>
        </div>

        <div>
            <label for="image" >📷</label>
            <input type="file" @change="onFileChange" />
        </div>

        <div v-if="totalPages > 1" class="pagination">
            <button @click="changePage(currentPage - 1)" :disabled="currentPage === 1">Poprzednia</button>
            <span>Page {{ currentPage }} of {{ totalPages }}</span>
            <button @click="changePage(currentPage + 1)" :disabled="currentPage === totalPages">Następna</button>
        </div>

    </body>
</template>

<script>
import GalleryService from "../GalleryService"
import { format } from "date-fns";

export default {
    data() {
        return {
            images: [],
            loading: false,
            error: null,
            currentPage: 1,
            pageSize: 5,
            totalPages: 0,
        };
    },

    mounted() {
        this.fetchImages();
    },

    methods: {
        async fetchImages(page) {
            this.loading = true;
            this.error = null;
            GalleryService.fetchImages(page)
                .then((data) => {
                    this.images = data.data;
                    this.totalPages = data.totalPages;
                })
                .catch((error) => {
                    this.error = error.message;
                })
                .finally(() => {
                    this.loading = false;
                })
        },

        async saveImages() {

        },

        changePage(page) {
            if (page >= 1 && page <= this.totalPages) {
                this.currentPage = page;
                this.fetchImages(page);
            }
        }
    },
};
</script>

<style scoped>
#error {
    color: red;
}

ul {
    list-style-type: none;
    padding: 0;
}

li {
    border: 1px solid #000000;
    padding: 15px;
    margin: 10px 0;
    border-radius: 5px;
}

h1 {
    background-color: #4CAF50;
    padding: 20px;
    margin: 0px auto;
    width: 80%;
    box-sizing: border-box;
}

body {
    background-color: #4CAF50;
    margin: 0 auto;
    padding: 0;
    color: #333;
    width: 80%;
    box-sizing: border-box;
    display: flex;
    flex-direction: column;
}

div {
    border-radius: 15px;
    padding: 20px;
    margin: 30px auto;
    max-width: 600px;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
    background-color: #FFF9C4;
}

h2 {
    font-size: 2em;
    margin-bottom: 10px;
    text-shadow: 1px 1px #FFD9E8;
}

p {
    font-size: 1.2em;
    line-height: 1.5;
    margin: 5px 0;
    color: #555;
}

.image {
    width: 100px;
    height: 100px;
}

strong {
    font-weight: bold !important
}
</style>
