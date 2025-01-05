<template>
    <div>
        <div v-if="loading">Wczytywanie Obrazów</div>
        <div v-if="error" class="error">{{ error }}</div>
        <!-- <i class="fa fa-window-close"></i> -->
        <!-- <button class="btn btn-danger">123123</button> -->

        <!-- <ul v-if="images.length">
                <li v-for="(image, index) in images" :key="image.id">
                    <img v-if="image.fileName !== null" :src="image.fileName" alt="Image" class="image"
                        @click="selectedImageIndex = index; imageModal = true" />
                </li>
            </ul> -->

        <div id="absolute">
            <h1 class="page-title">Galeria</h1>
            <div class="row" v-if="images.length" id="middle-block">
                <div class="col-6 col-sm-4 col-md-3 mb-3" v-for="(image, index) in images" :key="image.id">
                    <img v-if="image.fileName !== null" :src="image.fileName" alt="Image"
                        class="img-fluid rounded shadow-sm" @click="selectedImageIndex = index; imageModal = true" />
                </div>
            </div>
            <div v-if="totalPages > 1" id="pagination">
                <button @click="changePage(currentPage - 1)" :disabled="currentPage === 1">Poprzednia</button>
                <span>Page {{ currentPage }} of {{ totalPages }}</span>
                <button @click="changePage(currentPage + 1)" :disabled="currentPage === totalPages">Następna</button>
            </div>
        </div>
        <!-- 

            <div>
                <label for="image">📷</label>
                <input type="file" @change="onFileChange" />
                <button class="post-button" @click="saveImages">Post</button>
            </div> -->



        <ImageModal v-model="imageModal" :initialImages="images" :initialIndex="selectedImageIndex"
            :initialPage="currentPage" :totalPages="totalPages"></ImageModal>
    </div>

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
            pageSize: 3,
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

#pagination {
    display: flex;
    align-items: center;
    justify-content: space-between;
    gap: 10px;
}

#pagination span {
    flex: 1;
    text-align: center;
}

</style>
