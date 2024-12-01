<template>

    <body>

        <div class="post-container">
            <h2>Create New Post</h2>
            <!-- <textarea v-model="post.content" class="text-box" placeholder="Write your post here..."></textarea> -->

            <div>
                <vue-editor v-model="post.content"></vue-editor>
            </div>

            <!-- <div class="upload-section">
                <label for="file-upload" class="upload-icon">📷</label>
                <input type="file" id="file-upload" class="file-input" accept="image/*">
                <span>Select an image to upload</span>
            </div> -->
            <button class="post-button" @click="savePost">Post</button>
        </div>
        <div>
            <button @click="logout">Logout</button>
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
        async fetchPosts() {
            await pageService.getPosts().then(posts => {
                this.posts = posts;
            })
        },

        savePost() {
            PostService.createPost(this.post)
                .then((post) => {
                    alert("post is added")
                })
                .catch((error) => {
                    alert(`error, potst not added ${error}`)
                })
        },

        logout() {
            try {
                localStorage.removeItem('user');
                console.log('User has been logged out.');
            } catch (error) {
                console.error('Error during logout:', error);
            }
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
body {
    font-family: Arial, sans-serif;
    display: flex;
    justify-content: center;
    align-items: center;
    min-height: 100vh;
    margin: 0;
    background-color: #f2f2f2;
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
    color: #333;
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