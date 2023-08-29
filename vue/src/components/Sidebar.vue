<template>
  <section class="sidebar">
    <div class="user-info">
        <img src="https://fastly.picsum.photos/id/1011/60/60.jpg?hmac=4II0YyADT2KJxllHkW78APiqvJhLFYqmxdcYgE0_VcQ" class="avatar" />
        <h1>Andrew Clements</h1>
    </div>
    <ul>
        <li v-for="list in todoLists" :key="list.list_id" @click="setTodos(list.list_ID), setCurrentList(list.list_ID)"> {{ list.name }} 
            <span class="delete" @click="deleteList(list.list_ID)">×</span>
        </li>
    </ul>
    <input type="text" v-model="newList.name" placeholder="Enter list name">
    <button @click="createList()">New List</button>
    <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
  </section>
</template>

<script>
import ListService from "../services/ListService";
import TodoService from '../services/TodoService';

export default {
    name: "sidebar",
    created() {
        this.getLists(this.$store.state.user.userId);
    },
    data() {
        return {
        newList: {
            list_id: 0,
            name: "",
            user_id: this.$store.state.user.userId
        }
        }
    },
    methods: {
        async getLists(id) {
    try {
        const response = await ListService.getLists(id);
        this.$store.commit("SET_LISTS", response.data);
        if(response.status === 200) {
                this.setCurrentList(this.$store.state.lists[0].list_ID)
            }

    } catch (error) {
        // Handle the error here (e.g., show an error message, log the error, etc.)
        console.error("Error fetching todo lists:", error);
    }},
        createList() {
            ListService
            .createList(this.newList)
            .then(response => {
                if (response.status === 200) {
                    this.getLists(this.$store.state.user.userId);
                    this.newList.name = "";
                }
            });   
        },
        deleteList(id) {
            ListService
            .deleteList(id)
            .then(response => {
                if (response.status === 200) {
                    this.getLists(this.$store.state.user.userId);
                    this.setTodos(this.$store.state.lists[0].list_ID);
                }
            });
        },
         async setTodos(id) {
    try {
        const response = await TodoService.getTodos(id);
        this.$store.commit("SET_TODOS", response.data);
    } catch (error) {
        // Handle the error here (e.g., show an error message, log the error, etc.)
        console.error("Error fetching todo lists:", error);
    }},
        async setCurrentList(id) {
            try {
                const response = await ListService.getList(id);
                this.$store.commit("SET_CURRENT_LIST", response.data);
            } catch (error) {
        // Handle the error here (e.g., show an error message, log the error, etc.)
        console.error("Error fetching todo list:", error);
    }}

    },
    computed: {
        todoLists() {
            return this.$store.state.lists;
        }
    }
}
</script>

<style>
    .sidebar {
        background-color: dodgerblue;
        color: white;
        width: 250px;
        height: 100vh;
    }
    .sidebar>ul,h1 {
        padding: 0px 15px;
    }
    .sidebar>button {
        margin: 0px 15px;
    }

    .sidebar>ul {
        margin-bottom: 25px;
    }

    .sidebar>input[type=text] {
        margin: 0px 0px 10px 15px;
    }

    .user-info {
        display: flex;
        justify-content: center;
        margin-top: 25px;
        margin-bottom: 25px;
        align-items: center;
    }

    .user-info>img {
        border-radius: 20px;
        width: 45px;
        padding-right: 5px;
    }

    .delete {
    color: red;
    cursor: pointer;
    display: block;
    float: right;
    }  
</style>