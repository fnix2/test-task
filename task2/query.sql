-- По сути вопрос сводиться к использованию связи много-ко-многим.
-- В реляционных базах эта связь имитируется через промежуточную таблицу,
-- в данном случае ProductsCategoriesAssociation.


-- Создание таблиц

CREATE TABLE Products (
  productId INT NOT NULL PRIMARY KEY,
  productName NVARCHAR(100) NOT NULL,
);

CREATE TABLE Categories (
  categoryId INT NOT NULL PRIMARY KEY,
  categoryName NVARCHAR(100) NOT NULL,
);

CREATE TABLE ProductsCategoriesAssociation(
  categoryId INT NOT NULL,
  productId INT NOT NULL,
  PRIMARY KEY (categoryId, productId),
  FOREIGN KEY (categoryId) REFERENCES Categories(categoryId),
  FOREIGN KEY (productId) REFERENCES Products(productId)
)

-- Тестовые данные

INSERT INTO Categories(categoryId, categoryName) VALUES (1, N'Выпечка');
INSERT INTO Categories(categoryId, categoryName) VALUES (2, N'Еда');
INSERT INTO Categories(categoryId, categoryName) VALUES (3, N'Хлеб');
INSERT INTO Categories(categoryId, categoryName) VALUES (4, N'Напитки');
INSERT INTO Categories(categoryId, categoryName) VALUES (5, N'Канцтовары');
INSERT INTO Categories(categoryId, categoryName) VALUES (6, N'Техника');

INSERT INTO Products(productId, productName) VALUES (1, N'Хлеб Даниловский');
INSERT INTO Products(productId, productName) VALUES (2, N'Сок Добрый');
INSERT INTO Products(productId, productName) VALUES (3, N'Лампа настольная');
INSERT INTO Products(productId, productName) VALUES (4, N'Тетрадь детская, в клеточку');
INSERT INTO Products(productId, productName) VALUES (5, N'Слойка с сыром');
INSERT INTO Products(productId, productName) VALUES (6, N'Ручка шариковая, синяя');


INSERT INTO ProductsCategoriesAssociation(categoryId, productId) VALUES (1, 1);
INSERT INTO ProductsCategoriesAssociation(categoryId, productId) VALUES (2, 1);
INSERT INTO ProductsCategoriesAssociation(categoryId, productId) VALUES (3, 1);
INSERT INTO ProductsCategoriesAssociation(categoryId, productId) VALUES (4, 2);
INSERT INTO ProductsCategoriesAssociation(categoryId, productId) VALUES (5, 4);
INSERT INTO ProductsCategoriesAssociation(categoryId, productId) VALUES (1, 5);
INSERT INTO ProductsCategoriesAssociation(categoryId, productId) VALUES (2, 5);
INSERT INTO ProductsCategoriesAssociation(categoryId, productId) VALUES (5, 6);

-- Сам запрос

SELECT productName, categoryName FROM Products
    LEFT JOIN ProductsCategoriesAssociation ON ProductsCategoriesAssociation.productId = Products.productId
    LEFT JOIN Categories ON Categories.categoryId = ProductsCategoriesAssociation.categoryId;