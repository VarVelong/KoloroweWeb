<template>

    <body>
        <div class="post-container">
            <h1 class="page-title">Stwórz Nowy Post</h1>
            <div id="title-div">
                <label for="title">Tytuł:</label>
                <input v-model="post.title"/>
            </div>
            <div class="upload-container">
                <label for="image-upload" class="upload-label">
                    <span class="upload-icon">📷</span>
                    <span class="upload-text">Kliknij żeby wgrać zdjęcie.</span>
                </label>
                <input type="file" id="image-upload" class="upload-input" @change="onFileChange" />
            </div>
            <vue-editor v-model="post.content"></vue-editor>
            <button class="button-orange" @click="savePost">Post</button>
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
                title: "",
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
                    this.$router.push({ name: 'post-list' })
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
    background: #ddd;
    padding: 20px;
    max-width: 500px;
    width: 100%;
    border-radius: 8px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    margin-bottom: 100px;
}

.post-container h2 {
    margin-bottom: 20px;
    color: #ffffff;
}

button {
    width: 100%;
    margin: 10px;
}

#title-div {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-bottom: 20px;
}

#title-div label {
    font-weight: bold;
    margin-bottom: 5px;
}

#title-div textarea {
    width: 100%;
    max-width: 400px;
    min-height: 50px;
    resize: vertical;
    border: 1px solid #ccc;
    border-radius: 4px;
    padding: 8px;
    font-size: 14px;
}

.upload-container {
    width: 100%;
    max-width: 400px;
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

input{
    color: white;
}
</style>