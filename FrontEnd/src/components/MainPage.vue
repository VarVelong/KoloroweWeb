<template>
    <div class="main">
        <h1>Witamy w kolorowym przedszkolu</h1>
        <button class="button-orange" @click="$router.push({ name: 'offer' })">Zobacz naszą ofertę</button>
        <button class="button-orange" @click="$router.push({ name: 'contact' })">Umów wizytę</button>
    </div>
</template>

<style scoped>
div {
    background-color: rgba(0, 0, 0, 0.5);
    width: 80%;
    border: 3px solid black;
    border-radius: 15px;
    padding: 20px;
    margin: 30px auto;
    box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
    text-align: center;
}
</style>
