<template>
    <b-modal v-model="open" title="imageView" id="modal" size="xl">
        <spinner v-if="loading || !currentImages || !currentImages[currentIndex]" class="mx-auto self-center"></spinner>
        <div v-else>

            <button :disabled="currentIndex == 0 && currentPage == 1" @click="currentIndex--; changeImage()"><i
                    class="fas fa-arrow-left"></i></button>
            <img :src="currentImages[currentIndex].fileName" alt="Image" class="image" />
            <button :disabled="currentIndex >= currentImages.length - 1 && currentPage >= totalPages"
                @click="currentIndex++; changeImage()"><i class="fas fa-arrow-right"></i></button>


            <button class="btn btn-danger" @click="deleteImage(currentImages[currentIndex].id)"><i class="fas fa-trash-alt"></i></button>

            <!-- leave it for now -->
            <!-- <h2>{{ currentPage }} {{ totalPages }}</h2> -->
        </div>
    </b-modal>
</template>

<script>
import GalleryService from "../GalleryService"

export default {
    props: {
        initialImages: {
            type: Array,
            required: true
        },
        initialIndex: {
            type: Number,
            required: true
        },
        initialPage: {
            type: Number,
            required: false,
            default: 0
        },
        totalPages: {
            type: Number,
            required: false,
            default: 1
        }
    },

    data() {
        return {
            loading: false,
            open: false,
            error: null,
            currentPage: 1,
            currentIndex: 0,
            currentImages: []
        }
    },

    watch: {
        initialPage() {
            if (this.initialPage) {
                this.currentPage = this.initialPage;
            }
        },
        initialIndex() {
            if (this.initialIndex) {
                this.currentIndex = this.initialIndex;
            }
        },
        initialImages() {
            if (this.initialImages) {
                this.currentImages = this.initialImages;
            }
        }
    },

    methods: {
        changeImage() {

            if (this.currentIndex >= 0 && this.currentIndex < this.currentImages.length) {
                return;
            }

            if (this.currentIndex < 0) {
                this.currentPage--;
            } else {
                this.currentPage++;

            }

            this.loading = true;
            this.error = null;
            GalleryService.fetchImages(this.currentPage)
                .then((data) => {
                    this.currentImages = data.data;
                    if (this.currentIndex < 0) {
                        this.currentIndex = this.currentImages.length - 1;
                    } else {
                        this.currentIndex = 0;
                    }
                })
                .catch((error) => {
                    this.error = error.message;
                })
                .finally(() => {
                    this.loading = false;
                })
        },

        deleteImage(id) {
            const confirmation = confirm("Are you sure you want to delete this post?");

            if (confirmation) {
                GalleryService.deleteImage(id)
                .then((data) => {
                    alert("Image deleted successfully.");
                    this.$router.push("/gallery");
                })
                .catch((error) => {
                    alert(`Failed to delete image: ${error.message}`);
                })
            }
        }
    }
}
</script>

<style scoped>
div {
  background-color: #FFF9C4; 
  border: 3px solid #FFD54F;
  border-radius: 15px;
  padding: 20px;
  margin: 30px auto;
  box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
  text-align: center; 
}

img {
    width: 500px;
    height: 500px;
}
</style>
