<template>
    <bs-modal v-model="open" title="Image View">
        <spinner v-if="loading" class="mx-auto self-center"></spinner>
        <div v-else>
            <img v-if="images[selectedImageIndex] !== null" :src="images[selectedImageIndex]" alt="Image" class="image" />
        </div>
    </bs-modal>
</template>

<script>

import modal from '~/mixins/modal'

export default {
    mixins: [modal],

    props: {
        images:{
            type: Array,
            required: true
        },
        selectedImageIndex:{
            type: Number,
            required: true
        }
    },

    data() {
        return {
            loading: false,
        }
    }
}
