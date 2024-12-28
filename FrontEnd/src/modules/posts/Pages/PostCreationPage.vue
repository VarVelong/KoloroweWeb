<template>
    <body>

        <div class="post-container">
            <h2>Create New Post</h2>
            
            <div>
                <vue-editor v-model="post.content"></vue-editor>
            </div>

            <button class="post-button" @click="savePost">Post</button>
        </div>

        <div>
            <label for="image" lass="upload-icon">📷</label>
            <input type="file" @change="onFileChange" />
        </div>

    </body>
</template>

<script>
import PostService from "../PostService"
import { VueEditor } from "vue3-editor";

export default {
    data() {
        return {
            post: {
                date: new Date(),
                content: "",
                image: null
            }
        }
    },

    components: {
        VueEditor
    },

    methods: {
        savePost() {
            PostService.createPost(this.post)
                .then((post) => {
                    alert("post is added")
                })
                .catch((error) => {
                    alert(`error, potst not added ${error}`)
                })
        },

        onFileChange(event) {
            const file = event.target.files[0];
            if (file) {
                this.post.image = file;
            }
        }
    }
}

</script>

<style scoped>
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