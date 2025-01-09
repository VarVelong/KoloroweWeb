<template>
    <b-modal v-model="open" id="modal" size="xl" hide-footer>
        <div v-if="!loading && currentImages && currentImages[currentIndex]">
            <button :disabled="currentIndex == 0 && currentPage == 1" @click="currentIndex--; changeImage()"><i
                    class="fas fa-arrow-left"></i></button>
            <img :src="currentImages[currentIndex].fileName" alt="Image" class="image" />
            <button :disabled="currentIndex >= currentImages.length - 1 && currentPage >= totalPages"
                @click="currentIndex++; changeImage()"><i class="fas fa-arrow-right"></i></button>
            <button v-if="$isLoggedIn()" class="btn btn-danger" @click="deleteImage(currentImages[currentIndex].id)"><i class="fas fa-trash-alt"></i></button>
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
        },
        open() {
            this.currentPage = this.initialPage;
            this.currentIndex = this.initialIndex;
            this.currentImages = this.initialImages;
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

<!-- <style scoped>
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
</style> -->

<style scoped>
/* Modal Container */
#modal {
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 20px;
    background-color: rgba(0, 0, 0, 0.6); /* Dim background for focus */
}

/* Image Container */
div {
    background-color: #ffffff;
    border: 3px solid #FFAB40;
    border-radius: 15px;
    padding: 20px;
    margin: 30px auto;
    box-shadow: 0px 6px 12px rgba(0, 0, 0, 0.2);
    text-align: center;
    max-width: 90%; /* Responsive for smaller screens */
}

/* Image Styling */
img {
    width: 100%;
    max-width: 600px;
    height: auto;
    border-radius: 10px;
    box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
    margin: 20px 0;
}

/* Buttons */
button {
    background-color: #FF7043;
    color: white;
    border: none;
    border-radius: 5px;
    padding: 10px 15px;
    font-size: 16px;
    cursor: pointer;
    margin: 10px;
    transition: all 0.3s ease;
}

button:disabled {
    background-color: #FFCCBC;
    cursor: not-allowed;
}

button:hover:not(:disabled) {
    background-color: #D84315;
}

/* Icon Styling */
button i {
    margin-right: 5px;
}

/* Danger Button */
.btn-danger {
    background-color: #D32F2F;
}

.btn-danger:hover {
    background-color: #B71C1C;
}

/* Loading Spinner */
.loading-spinner {
    border: 5px solid #FFAB40;
    border-top: 5px solid #FF7043;
    border-radius: 50%;
    width: 40px;
    height: 40px;
    animation: spin 1s linear infinite;
    margin: auto;
}

/* Spinner Animation */
@keyframes spin {
    0% {
        transform: rotate(0deg);
    }
    100% {
        transform: rotate(360deg);
    }
}

/* Responsive Design */
@media (max-width: 768px) {
    div {
        padding: 15px;
    }

    img {
        max-width: 100%;
        height: auto;
    }

    button {
        font-size: 14px;
        padding: 8px 12px;
    }
}
</style>