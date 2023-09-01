import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    user_info: {},
    lists: [],
    todos: [],
    completed: [],
    currentList: {
      list_id: "",
      name: "",
      user_id: ""
    }
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    GET_USER_INFO(state, user_info) {
      state.user_info = user_info;
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    SET_LISTS(state, data) {
      state.lists = data;
    },
    SET_CURRENT_LIST(state, data) {
      state.currentList = data;
    },
    SET_TODOS(state, data) {
      state.todos = data;
    },
    SET_COMPLETED(state, data) {
      state.completed = data;
    },
    FLIP_DONE(state, todoToChange) {
      todoToChange.isComplete = ! todoToChange.isComplete;
    }
  }
})
