<template>
  <div class="home">
    <div class="sidebar">
      <sidebar />
    </div>
    <div class="todo">
      <todo-list />
    </div>
  </div>
</template>

<script>
import Sidebar from '../components/Sidebar.vue';
import TodoList from '../components/TodoList.vue';

export default {
  name: "home",
  components: { 
    TodoList, 
    Sidebar 
    },
};
</script>

<style scoped>
  .home {
    display: flex;
  }
</style>
