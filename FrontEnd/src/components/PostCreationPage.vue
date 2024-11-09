<template>
    <body>
    
    <div class="post-container">
        <h2>Create New Post</h2>
        <textarea v-model="post.content" class="text-box" placeholder="Write your post here..."></textarea>
        <div class="upload-section">
            <label for="file-upload" class="upload-icon">📷</label>
            <input type="file" id="file-upload" class="file-input" accept="image/*">
            <span>Select an image to upload</span>
        </div>
        <button class="post-button" @click="savePost">Post</button>
    </div>

    </body>
</template>
    
<!-- <style scoped>
body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
}
</style> -->

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
            background: #fff;
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

<script>
import PostService from "../router/PostService";

export default{
    data(){
        return {
            post: {
                date:"",
                content:"",
                image:""
            }
        }
    },

    async mounted() {

    },

    methods:{
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
        }
    }
}

// saveGame() {
//             //test this, test modal on save and load, change modal button, fix field
//             let saveGameData = this.getSaveGameData();
//             if (this.saves.length <= this.maxSaveNumber) {
//                 MapService.createSave(saveGameData, SaveType.UserSave).then(save => {

//                     alert("Game Saved");
//                     this.fetchSaves();
//                 });
//             }
//             else {
//                 this.isSaving = true;
//                 this.modal.saves = true;
//             }
//         },

</script>