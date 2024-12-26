<template>
    <Modal :modalActive="open">
        <spinner v-if="loading" class="mx-auto self-center"></spinner>
        <div v-else>
            <h2>{{ (images[selectedImageIndex]).fileName }}</h2>;
            <button @click="test">1212</button>
            <img v-if="images[selectedImageIndex] !== null" :src="images[selectedImageIndex]" alt="Image" class="image" />
        </div>
    </Modal>
</template>

<script>
import Modal from '../../../components/Modal.vue'

export default {
    props: {
        images:{
            type: Array,
            required: true
        },
        selectedImageIndex:{
            type: Number,
            required: true
        },
        open:{
            type: Boolean,
            required: true
        }
    },

    components: {
        Modal
    },

    data() {
        return {
            loading: false,
        }
    },

    methods:{
        test(){
            debugger;
        }
    }
}
</script>
