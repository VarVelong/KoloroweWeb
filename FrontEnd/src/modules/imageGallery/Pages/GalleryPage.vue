<template>
    <div>
        <!-- <div v-if="loading">Wczytywanie Obrazów</div>
        <div v-if="error" class="error">{{ error }}</div> -->

        <div id="absolute">
            <h1 class="page-title">Galeria</h1>
            <div class="row" v-if="images.length" id="middle-block">
                <div class="col-6 col-sm-4 col-md-3 mb-3" v-for="(image, index) in images" :key="image.id">
                    <img v-if="image.fileName !== null" :src="image.fileName" alt="Image"
                        class="img-fluid rounded shadow-sm" @click="selectedImageIndex = index; imageModal = true" />
                </div>
            </div>

        </div>

        <div v-if="totalPages > 1" id="pagination">
            <button class="button-orange" @click="changePage(currentPage - 1)"
                :disabled="currentPage === 1">Poprzednia</button>
            <span>Strona {{ currentPage }} z {{ totalPages }}</span>
            <button class="button-orange" @click="changePage(currentPage + 1)"
                :disabled="currentPage === totalPages">Następna</button>
        </div>


        <!-- <div>
                <label for="image">📷</label>
                <input type="file" @change="onFileChange" />
                <button class="post-button" @click="saveImages">Post</button>
            </div> -->

        <div v-if="$isLoggedIn()" class="upload-container" @dragover.prevent="onDragOver" @dragleave="onDragLeave"
            @drop="onDrop" :class="{ 'upload-active': isDragOver }">
            <label for="image-upload" class="upload-label">
                <span class="upload-icon">📷</span>
                <span class="upload-text">Kliknij żeby wgrać zdjęcie.</span>
            </label>
            <input type="file" id="image-upload" class="upload-input" @change="onFileChange" />
            <img v-if="previewImage" :src="previewImage" alt="Preview" class="image-preview" />
            <button id="post-button" @click="saveImages">Post</button>
        </div>


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
            pageSize: 15,
            totalPages: 0,
            uploadedImage: null,
            imageModal: false,
            selectedImageIndex: 0,
            previewImage: null,
            isDragOver: false
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
                this.previewImage = URL.createObjectURL(file);
            }
        },

        changePage(page) {
            if (page >= 1 && page <= this.totalPages) {
                this.currentPage = page;
                this.fetchImages(page);
            }
        },

        onDragOver() {
            this.isDragOver = true;
        },
        onDragLeave() {
            this.isDragOver = false;
        },
        onDrop(event) {
            event.preventDefault();
            this.isDragOver = false;
            const file = event.dataTransfer.files[0];
            if (file) {
                this.uploadedImage = file;
                this.previewImage = URL.createObjectURL(file);
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

#middle-block {
    background-color: rgba(0, 0, 0, 0.5);
    margin: 15px;
    padding: 15px;
    border-radius: 15px;
}

#pagination {
    display: flex;
    align-items: center;
    justify-content: space-between;
    gap: 10px;
    margin-bottom: 100px;
    background-color: #ddd;
    border-radius: 15px;
    width: 80%;
    padding: 20px;
    margin: 30px auto;
    margin-top: 15px;
    text-align: center;
}

.upload-container {
    width: 100%;
    max-width: 80%;
    margin: 20px auto;
    padding: 20px;
    border: 2px dashed #3498db;
    border-radius: 10px;
    text-align: center;
    background-color: #f9f9f9;
    position: relative;
    transition: border-color 0.3s ease, background-color 0.3s ease;
}

.upload-container:hover {
    border-color: #2980b9;
    background-color: #ecf0f1;
}

.upload-label {
    display: flex;
    flex-direction: column;
    align-items: center;
    cursor: pointer;
}

.upload-icon {
    font-size: 3rem;
    color: #3498db;
    margin-bottom: 10px;
}

.upload-text {
    font-size: 1rem;
    color: #7f8c8d;
}

.upload-input {
    display: none;
}

input {
    color: white;
}

.image-preview{
    max-width: 512px;
    max-height: 512px;
}

#post-button{
    background-color: #7f8c8d;
    color: black;
}
</style>
