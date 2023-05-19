/*
 Navicat Premium Data Transfer

 Source Server         : Local
 Source Server Type    : MySQL
 Source Server Version : 80033 (8.0.33)
 Source Host           : localhost:3306
 Source Schema         : restauranteweb

 Target Server Type    : MySQL
 Target Server Version : 80033 (8.0.33)
 File Encoding         : 65001

 Date: 19/05/2023 02:20:24
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for cliente
-- ----------------------------
DROP TABLE IF EXISTS `cliente`;
CREATE TABLE `cliente`  (
  `NR_ID_CL` int NOT NULL AUTO_INCREMENT,
  `TX_NOME_CL` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `TX_DOCUMENTO_CL` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `NR_MESA_CL` int NOT NULL,
  PRIMARY KEY (`NR_ID_CL`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for pedido
-- ----------------------------
DROP TABLE IF EXISTS `pedido`;
CREATE TABLE `pedido`  (
  `NR_ID_PE` int NOT NULL AUTO_INCREMENT,
  `NR_CLIENTE_ID_PE` int NOT NULL,
  `NR_PRATO_ID_PE` int NOT NULL,
  `NR_MESA_PE` int NOT NULL,
  `NR_VALOR_PE` decimal(6, 2) NOT NULL,
  `TX_STATUS_PE` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Enviado para Cozinha/Aceito/Preparando/A Caminho da mesa/Finalizado',
  PRIMARY KEY (`NR_ID_PE`) USING BTREE,
  INDEX `NR_CLIENTE_ID_PE`(`NR_CLIENTE_ID_PE` ASC) USING BTREE,
  INDEX `NR_PRATO_ID_PE`(`NR_PRATO_ID_PE` ASC) USING BTREE,
  CONSTRAINT `pedido_ibfk_1` FOREIGN KEY (`NR_CLIENTE_ID_PE`) REFERENCES `cliente` (`NR_ID_CL`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `pedido_ibfk_2` FOREIGN KEY (`NR_PRATO_ID_PE`) REFERENCES `prato` (`NR_ID_PR`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for prato
-- ----------------------------
DROP TABLE IF EXISTS `prato`;
CREATE TABLE `prato`  (
  `NR_ID_PR` int NOT NULL AUTO_INCREMENT,
  `TX_NOME_PR` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `TX_DESCRICAO_PR` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `TX_CATEGORIA_PR` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `TX_PREPARO_PR` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `NR_VALOR_PR` decimal(6, 2) NOT NULL,
  `ST_STATUS_PR` tinyint NOT NULL,
  PRIMARY KEY (`NR_ID_PR`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
