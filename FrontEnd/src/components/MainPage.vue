<template>
    <body>

        <div class="main">
            <h1>Witamy w kolorowym przedszkolu</h1>
            <button id="a-button" @click="$router.push({ name: 'offer'})">Zobacz naszą ofertę</button>
            <button id="a-button" @click="$router.push({ name: 'contact'})">Umów wizytę</button>
        </div>

    </body>
</template>

<style scoped>
body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
}

.main {
    background: #367938;
    padding: 50px;
    text-align: center;
    margin: 15px;
}

#a-button {
    background: #4CAF50;
    color: white;
    padding: 10px 20px;
    text-decoration: none;
}
</style>
