<template>
  <div id="app">
    <div id="nav" v-if="this.$route.name != 'login' && this.$route.name != 'register'">
      <div class="name" v-if="this.$route.name == 'home' || this.$route.name == 'profile'">
        <h1>Andysoft To Do</h1>
      </div>
      <div class="links">
        <router-link v-bind:to="{ name: 'home' }" v-if="this.$route.name == 'profile'">Home</router-link>
        <router-link v-bind:to="{ name: 'profile' }" v-if="$store.state.token != '' && this.$route.name != 'profile'">Profile</router-link>
        <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
      </div>

    </div>
    <router-view />
  </div>
</template>

<style scoped>
html,
body {
  margin: 0px;
  height: 100%;
}
#app {
  background-color: white;
  /* font-family: Montserrat; */
  height: 100vh;
  width: 100%;
  /* position: fixed; */
}

#nav {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 50px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 0px 20px;
  color: white;
  background-color: #4368E3;
}

.links>a {
  margin-right: 15px;
}

.links>a,a:visited {
        color: white;
    }

    .links>a:hover {
        color: rgb(203, 194, 252);
    }

</style>
