<template>
    <div class="user-profile">
        <div class="profile-info">
        <img src="https://fastly.picsum.photos/id/1011/60/60.jpg?hmac=4II0YyADT2KJxllHkW78APiqvJhLFYqmxdcYgE0_VcQ" class="avatar" />
        <h1>Andrew Clements</h1>
        <router-link v-bind:to="{ name: 'home' }" v-if="$store.state.token != ''">Home</router-link>
        </div>
    </div>
</template>

<script>
export default {
    name: 'profile'
}
</script>

<style>
.user-profile {
  display: flex;
  background-color: dodgerblue;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 100%;
  height: 100vh;
}

.profile-info {
  padding: 32px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  max-width: 400px;
  width: 90%;
  text-align: center;
  color: white;
  text-shadow: 2px 2px 2px rgba(0,0,0,0.14);
  background: rgba(255, 255, 255, 0.1); 
  border-radius: 10px; 
  backdrop-filter: blur(3px); 
  border: 1px solid rgba(255, 255, 255, 0.2);
}

.avatar {
    border-radius: 100px;
        width: 200px;
        padding-right: 5px;
}
</style>