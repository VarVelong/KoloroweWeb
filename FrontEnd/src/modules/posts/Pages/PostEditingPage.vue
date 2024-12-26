<template>

    <body>
        <div class="post-container">
            <h2>Edit Post</h2>
            <div>
                <vue-editor v-model="post.content"></vue-editor>
            </div>
            <button class="post-button" @click="savePost">Post</button>
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
body {
    font-family: Arial, sans-serif;
    display: flex;
    justify-content: center;
    align-items: center;
    min-height: 100vh;
    margin: 0;
    background-color: #4CAF50;
    display: flex;
    flex-direction: column;
}

.post-container {
    background: #2e2b2b;
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

.text-box {
    width: 100%;
    min-height: 150px;
    padding: 10px;
    border: 1px solid #ec0303;
    border-radius: 5px;
    resize: vertical;
    font-size: 16px;
}

.upload-section {
    display: flex;
    align-items: center;
    margin-top: 15px;
}

.upload-icon {
    font-size: 24px;
    color: #007bff;
    margin-right: 10px;
    cursor: pointer;
}

.file-input {
    display: none;
}

.post-button {
    display: block;
    width: 100%;
    padding: 10px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    font-size: 16px;
    margin-top: 20px;
}

.post-button:hover {
    background-color: #0056b3;
}
</style>
