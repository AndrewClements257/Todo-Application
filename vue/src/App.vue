<template>
  <div id="app">
   <!--
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
    -->
    <router-view />
  </div>
</template>

<style scoped>
#app {
  background-color: dodgerblue;
  background-size: cover;
  /* font-family: Montserrat; */
  min-height: 100vh;
  /* position: fixed; */
}

#nav {
  height: 50px;
  display: flex;
  align-items: center;
  margin: 0px 20px;
  color: white;
}

</style>
