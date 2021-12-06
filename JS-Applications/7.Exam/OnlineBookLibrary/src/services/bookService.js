import * as request from './requester.js';
import * as api from './api.js';

const getAll = () => request.get(api.catalog);

const getOne = (id) => request.get(`${api.books}/${id}`);

const create = (title, description, imageUrl, type) => request.post(`${api.books}`, 
{ title, description, imageUrl, type });

const update = (carId, title, description, imageUrl, type) => request.put(`${api.books}/${carId}`, 
{ title, description, imageUrl, type });

const deleteItem = (bookId) => request.del(`${api.books}/${bookId}`);

const myBooks = (userId) => request.get(`${api.books}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`)

const likeBook = (bookId) => request.post(`${api.likes}`, { bookId });

const likesCount = (bookId) => request.get(`${api.likes}?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`);

const likesFromUser = (bookId, userId) => request.get(`${api.likes}?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`)

 export default {
    getAll,
    getOne,
    create,
    update,
    deleteItem,
    myBooks,
    likeBook,
    likesCount,
    likesFromUser
 }