<template>
    <b-modal v-model="open" title="imageView" id="modal" size="xl">
        <spinner v-if="loading" class="mx-auto self-center"></spinner>
        <div v-else>
            <button @click="changeImage(index--, images[index].id)"><i class="fas fa-arrow-left"></i></button>
            <img v-if="images && images[index]" :src="images[index].fileName" alt="Image" class="image" />
            <button @click="changeImage(index++, images[index].id)"><i class="fas fa-arrow-right"></i></button>

            <!-- leave it for now -->
            <h2 v-if="images && images[index]">{{ index }}</h2>
        </div>
    </b-modal>
</template>

<script>
import GalleryService from "../GalleryService"

export default {
    props: {
        images: {
            type: Array,
            required: true
        },
        index: {
            type: Number,
            required: true
        }
    },

    data() {
        return {
            loading: false,
            open: false
        }
    },

    methods: {
        changeImage(index, currentId) {
            if (index >= 0 && index < this.images.length) {
                return;
            }
            
            this.loading = true;
            this.error = null;
            GalleryService.fetchImages()
                .then((data) => {
                    this.images = data.data;
                })
                .catch((error) => {
                    this.error = error.message;
                })
                .finally(() => {
                    this.loading = false;
                })
        }
    }
}
</script>

<!-- <style>
#modal, #modal div{
    background-color: white;
    border: 0px;
    border-radius: 0px;
    padding: auto;
    margin: auto;
    box-shadow: none !important;
    text-align: auto;
}
</style> -->

<style scoped>
img {
    width: 500px;
    height: 500px;
}
</style>