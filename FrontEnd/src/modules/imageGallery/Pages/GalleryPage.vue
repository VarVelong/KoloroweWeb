<template>
    <h1>Galeria</h1>

    <body>
        <div>
            <div v-if="loading">Wczytywanie Obrazów</div>
            <div v-if="error" class="error">{{ error }}</div>
            <!-- <i class="fa fa-window-close"></i> -->
            <!-- <button class="btn btn-danger">123123</button> -->
            <ul v-if="images.length">
                <li v-for="(image, index) in images" :key="image.id">
                    <img v-if="image.fileName !== null" :src="image.fileName" alt="Image" class="image" @click="selectedImageIndex=index;imageModal = true"/>
                    <!-- use bootstrap tiles -->
                </li>
            </ul>
        </div>

        <div>
            <label for="image" >📷</label>
            <input type="file" @change="onFileChange" />
            <button class="post-button" @click="saveImages">Post</button>
        </div>

        <div v-if="totalPages > 1" class="pagination">
            <button @click="changePage(currentPage - 1)" :disabled="currentPage === 1">Poprzednia</button>
            <span>Page {{ currentPage }} of {{ totalPages }}</span>
            <button @click="changePage(currentPage + 1)" :disabled="currentPage === totalPages">Następna</button>
        </div>

        <ImageModal v-model="imageModal" :images="images" :index="selectedImageIndex"></ImageModal>

    </body>
</template>

<script>
import GalleryService from "../GalleryService"
import { format } from "date-fns"
import ImageModal from "../Components/ImageModal.vue"

export default {
    data() {
        return {
            images: [],
            loading: false,
            error: null,
            currentPage: 1,
            pageSize: 5,
            totalPages: 0,
            uploadedImage: null,
            imageModal: false,
            selectedImageIndex: 0
        };
    },

    components: {
        ImageModal
    },

    mounted() {
        this.fetchImages();
    },

    methods: {
        async fetchImages(page) {
            this.loading = true;
            this.error = null;
            await GalleryService.fetchImages(page)
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
            GalleryService.createImage(this.uploadedImage)
                .then((uploadedImage) => {
                    alert("image is added")
                })
                .catch((error) => {
                    alert(`error, image not added ${error}`)
                })
        },

        onFileChange(event) {
            const file = event.target.files[0];
            if (file) {
                this.uploadedImage = file;
            }
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
.image {
    width: 100px;
    height: 100px;
}
</style>
