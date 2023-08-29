<template>
  <section class="new-todo">
    <form  v-on:submit.prevent="createTodo()">
        <input type="text" placeholder="Todo Name" v-model="newTodo.name"/>
        <button>Add</button>
    </form>
  </section>
</template>

<script>
import TodoService from '../services/TodoService';

export default {
data() {
        return {
        newTodo: {
            todo_id: 0,
            name: "",
            isComplete: false,
            list_id: 0
        }
        }
    },
    methods: {
         createTodo() {
            TodoService
            .newTodo(this.newTodo)   
        },
    },
    watch: {
    '$store.state.currentList.list_ID': function(newListId) {
      this.newTodo.list_id = newListId;
    }
    }
}
</script>

<style>
  .new-todo {
      padding-left: 50px;
      padding-bottom: 50px;
  }
</style>