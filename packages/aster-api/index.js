const express = require('express');

const app = express();
const router = express.Router();


router.get('/', (req, res) => {
  res.send('Hello World')
});

app.use(router);


const port = process.env.PORT || 5000;

app.listen(port, () => console.log(`Express running on port ${port}`));
