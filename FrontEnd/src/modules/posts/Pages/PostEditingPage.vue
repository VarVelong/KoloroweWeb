<template>
    <body>
        <div class="post-container">
            <h1 class="page-title">Edit Post</h1>
            <div>
                <vue-editor v-model="post.content"></vue-editor>
            </div>
            <button class="button-orange" @click="savePost">Post</button>
        </div>
    </body>
</template>

<script>
import PostService from "../PostService"
import { VueEditor } from "vue3-editor";

export default {
    props: ["id"],
    data() {
        return {
            post: {
                content: ""
            },
            loading: false,
            error: null
        }
    },

    mounted() {
        this.fetchPost()
    },

    components: {
        VueEditor
    },

    methods: {
        async fetchPost() {
            this.loading = true;
            this.error = null;
            PostService.getPost(this.id)
                .then((data) => {
                    this.post = data;
                })
                .catch((error) => {
                    this.error = error.message;
                })
                .finally(() => {
                    this.loading = false;
                })
        },

        async savePost() {
            this.loading = true;
            this.error = null;
            PostService.updatePost(this.id, this.post.content)
                .then((data) => {
                    this.post = data;
                    alert("Post został pomyślnie zapisany!")
                    this.$router.push('/post-list')
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

<style scoped>
.post-container {
    background: #ddd;
    padding: 20px;
    max-width: 500px;
    width: 100%;
    border-radius: 8px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.post-container h2 {
    margin-bottom: 20px;
    color: #ffffff;
}

button {
    width: 100%;
    margin: 10px;
}
</style>
