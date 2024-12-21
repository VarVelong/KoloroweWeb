<template>
    <body>
        <div>
            <button @click="$router.push({ name: 'offercreationpage'})">Create Offer</button>
        </div>
        <div>
            <button @click="$router.push({ name: 'postcreation'})">Create Post</button>
        </div>
    </body>
</template>

<script>


</script>

<style scoped>
body {
    background-color: #4CAF50;
    margin: 0 auto;
    padding: 0;
    color: #333;
    width: 80%;
    box-sizing: border-box;
}

div {
    background-color: #FFF9C4;
    border: 3px solid #FFD54F;
    border-radius: 15px;
    padding: 20px;
    margin: 0 auto;
    max-width: 600px;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
}

</style>