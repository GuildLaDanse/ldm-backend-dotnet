CREATE TABLE `CommentGroup` (
    `id` CHAR(36) NOT NULL,
    `postDate` DATETIME NOT NULL,
    CONSTRAINT `PK_CommentGroup` PRIMARY KEY (`id`)
);

CREATE TABLE `GameClass` (
    `id` CHAR(36) NOT NULL,
    `gameId` INT UNSIGNED NOT NULL,
    `name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_GameClass` PRIMARY KEY (`id`)
);

CREATE TABLE `GameFaction` (
    `id` CHAR(36) NOT NULL,
    `gameId` INT UNSIGNED NOT NULL,
    `name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_GameFaction` PRIMARY KEY (`id`)
);

CREATE TABLE `GameRealm` (
    `id` CHAR(36) NOT NULL,
    `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `gameId` INT UNSIGNED NOT NULL,
    CONSTRAINT `PK_GameRealm` PRIMARY KEY (`id`)
);

CREATE TABLE `MailSend` (
    `id` CHAR(36) NOT NULL,
    `sendOn` DATETIME NOT NULL,
    `fromAddress` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `toAddress` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `subject` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_MailSend` PRIMARY KEY (`id`)
);

CREATE TABLE `User` (
    `id` CHAR(36) NOT NULL,
    `externalId` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
    `email` varchar(180) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `displayName` varchar(35) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `displayNameByUser` tinyint(1) NOT NULL,
    CONSTRAINT `PK_User` PRIMARY KEY (`id`)
);

CREATE TABLE `GameRace` (
    `id` CHAR(36) NOT NULL,
    `gameId` INT UNSIGNED NOT NULL,
    `name` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `gameFactionId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_GameRace` PRIMARY KEY (`id`),
    CONSTRAINT `FK_D51A7CF883048B90` FOREIGN KEY (`gameFactionId`) REFERENCES `GameFaction` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `GameCharacter` (
    `id` CHAR(36) NOT NULL,
    `fromTime` DATETIME NOT NULL,
    `endTime` DATETIME NULL,
    `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `gameRealmId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_GameCharacter` PRIMARY KEY (`id`),
    CONSTRAINT `FK_92AF3B34FA96DBDA` FOREIGN KEY (`gameRealmId`) REFERENCES `GameRealm` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `GameGuild` (
    `id` CHAR(36) NOT NULL,
    `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `gameId` INT UNSIGNED NOT NULL,
    `gameRealmId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_GameGuild` PRIMARY KEY (`id`),
    CONSTRAINT `FK_B48152AFFA96DBDA` FOREIGN KEY (`gameRealmId`) REFERENCES `GameRealm` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `ActivityQueueItem` (
    `id` CHAR(36) NOT NULL,
    `activityType` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `activityOn` DATETIME NOT NULL,
    `rawData` LONGTEXT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
    `processedOn` DATETIME NULL,
    `activityById` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
    CONSTRAINT `PK_ActivityQueueItem` PRIMARY KEY (`id`),
    CONSTRAINT `FK_8A274BCA93C757EE` FOREIGN KEY (`activityById`) REFERENCES `User` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `CalendarExport` (
    `id` CHAR(36) NOT NULL,
    `exportNew` tinyint(1) NOT NULL,
    `exportAbsence` tinyint(1) NOT NULL,
    `secret` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `userId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_CalendarExport` PRIMARY KEY (`id`),
    CONSTRAINT `FK_6E28848862DEB3E8` FOREIGN KEY (`userId`) REFERENCES `User` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `Comment` (
    `id` CHAR(36) NOT NULL,
    `postDate` DATETIME NOT NULL,
    `content` varchar(4096) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `groupId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `posterId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_Comment` PRIMARY KEY (`id`),
    CONSTRAINT `FK_5BC96BF0ED8188B0` FOREIGN KEY (`groupId`) REFERENCES `CommentGroup` (`id`) ON DELETE CASCADE,
    CONSTRAINT `FK_5BC96BF0581A197` FOREIGN KEY (`posterId`) REFERENCES `User` (`id`) ON DELETE CASCADE
);

CREATE TABLE `Event` (
    `id` CHAR(36) NOT NULL,
    `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `description` varchar(4096) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
    `inviteTime` DATETIME NOT NULL,
    `startTime` DATETIME NOT NULL,
    `endTime` DATETIME NOT NULL,
    `lastModifiedTime` DATETIME NOT NULL,
    `state` TINYINT NOT NULL,
    `commentGroupId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `organiserId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_Event` PRIMARY KEY (`id`),
    CONSTRAINT `FK_FA6F25A34BDD4B9` FOREIGN KEY (`commentGroupId`) REFERENCES `CommentGroup` (`id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_FA6F25A34BDD3C8` FOREIGN KEY (`organiserId`) REFERENCES `User` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `FeatureToggle` (
    `id` CHAR(36) NOT NULL,
    `feature` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `toggle` tinyint(1) NOT NULL,
    `userId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_FeatureToggle` PRIMARY KEY (`id`),
    CONSTRAINT `FK_D25E05DD612E729E` FOREIGN KEY (`userId`) REFERENCES `User` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `FeatureUse` (
    `id` CHAR(36) NOT NULL,
    `usedOn` DATETIME NOT NULL,
    `feature` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `rawData` LONGTEXT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
    `usedById` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
    CONSTRAINT `PK_FeatureUse` PRIMARY KEY (`id`),
    CONSTRAINT `FK_E504F432FCEF271C` FOREIGN KEY (`usedById`) REFERENCES `User` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `Feedback` (
    `id` CHAR(36) NOT NULL,
    `postedOn` DATETIME NOT NULL,
    `feedback` LONGTEXT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `postedById` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_Feedback` PRIMARY KEY (`id`),
    CONSTRAINT `FK_2B5F260E9DD8CB47` FOREIGN KEY (`postedById`) REFERENCES `User` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `ForumLastVisit` (
    `id` CHAR(36) NOT NULL,
    `lastVisitDate` DATETIME NOT NULL,
    `userId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_ForumLastVisit` PRIMARY KEY (`id`),
    CONSTRAINT `FK_F17408662DEB3E8` FOREIGN KEY (`userId`) REFERENCES `User` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `NotificationQueueItem` (
    `id` CHAR(36) NOT NULL,
    `activityType` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `activityOn` DATETIME NOT NULL,
    `rawData` LONGTEXT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
    `processedOn` DATETIME NULL,
    `activityById` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
    CONSTRAINT `PK_NotificationQueueItem` PRIMARY KEY (`id`),
    CONSTRAINT `FK_C656D44393C757EE` FOREIGN KEY (`activityById`) REFERENCES `User` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `Setting` (
    `id` CHAR(36) NOT NULL,
    `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `value` varchar(2048) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `userId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_Setting` PRIMARY KEY (`id`),
    CONSTRAINT `FK_50C9810462DEB3E8` FOREIGN KEY (`userId`) REFERENCES `User` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `GameCharacterClaim` (
    `id` CHAR(36) NOT NULL,
    `fromTime` DATETIME NOT NULL,
    `endTime` DATETIME NULL,
    `userId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `gameCharacterId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_GameCharacterClaim` PRIMARY KEY (`id`),
    CONSTRAINT `FK_E115ED785AF690F3` FOREIGN KEY (`gameCharacterId`) REFERENCES `GameCharacter` (`id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_E115ED7862DEB3E8` FOREIGN KEY (`userId`) REFERENCES `User` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `GameCharacterVersion` (
    `id` CHAR(36) NOT NULL,
    `fromTime` DATETIME NOT NULL,
    `endTime` DATETIME NULL,
    `level` INT UNSIGNED NOT NULL,
    `gameCharacterId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `gameClassId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `gameRaceId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_GameCharacterVersion` PRIMARY KEY (`id`),
    CONSTRAINT `FK_A70EBD185AF690F3` FOREIGN KEY (`gameCharacterId`) REFERENCES `GameCharacter` (`id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_A70EBD18F3B4E37B` FOREIGN KEY (`gameClassId`) REFERENCES `GameClass` (`id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_A70EBD18E036C39A` FOREIGN KEY (`gameRaceId`) REFERENCES `GameRace` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `GameCharacterSource` (
    `id` CHAR(36) NOT NULL,
    `discr` char(15) NOT NULL,
    `gameGuildId` CHAR(36) NULL,
    `userId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
    CONSTRAINT `PK_GameCharacterSource` PRIMARY KEY (`id`),
    CONSTRAINT `FK_18BD775675407DAB` FOREIGN KEY (`gameGuildId`) REFERENCES `GameGuild` (`id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_70D670C87D3656A4` FOREIGN KEY (`userId`) REFERENCES `User` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `InGameGuild` (
    `id` CHAR(36) NOT NULL,
    `fromTime` DATETIME NOT NULL,
    `endTime` DATETIME NULL,
    `gameCharacterId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `gameGuildId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_InGameGuild` PRIMARY KEY (`id`),
    CONSTRAINT `FK_CA2244C5AF690F3` FOREIGN KEY (`gameCharacterId`) REFERENCES `GameCharacter` (`id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_CA2244C75407DAB` FOREIGN KEY (`gameGuildId`) REFERENCES `GameGuild` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `SignUp` (
    `id` CHAR(36) NOT NULL,
    `type` TINYINT NOT NULL,
    `userId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `eventId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_SignUp` PRIMARY KEY (`id`),
    CONSTRAINT `FK_DC8B3F7B2B2EBB6C` FOREIGN KEY (`eventId`) REFERENCES `Event` (`id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_DC8B3F7B62DEB3E8` FOREIGN KEY (`userId`) REFERENCES `User` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `GameCharacterClaimVersion` (
    `id` CHAR(36) NOT NULL,
    `fromTime` DATETIME NOT NULL,
    `endTime` DATETIME NULL,
    `comment` TEXT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
    `isRaider` tinyint(1) NOT NULL,
    `gameCharacterClaimId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_GameCharacterClaimVersion` PRIMARY KEY (`id`),
    CONSTRAINT `FK_C33F42E09113A92D` FOREIGN KEY (`gameCharacterClaimId`) REFERENCES `GameCharacterClaim` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `PlaysGameRole` (
    `id` CHAR(36) NOT NULL,
    `fromTime` DATETIME NOT NULL,
    `endTime` DATETIME NULL,
    `gameRole` TINYINT NOT NULL,
    `gameCharacterClaimId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_PlaysGameRole` PRIMARY KEY (`id`),
    CONSTRAINT `FK_7A9E9B239113A92D` FOREIGN KEY (`gameCharacterClaimId`) REFERENCES `GameCharacterClaim` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `GameCharacterSyncSession` (
    `id` CHAR(36) NOT NULL,
    `fromTime` DATETIME NOT NULL,
    `endTime` DATETIME NULL,
    `log` LONGTEXT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
    `gameCharacterSourceId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_GameCharacterSyncSession` PRIMARY KEY (`id`),
    CONSTRAINT `FK_EC73362CDD71BB` FOREIGN KEY (`gameCharacterSourceId`) REFERENCES `GameCharacterSource` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `TrackedBy` (
    `id` CHAR(36) NOT NULL,
    `fromTime` DATETIME NOT NULL,
    `endTime` DATETIME NULL,
    `gameCharacterId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `gameCharacterSourceId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_TrackedBy` PRIMARY KEY (`id`),
    CONSTRAINT `FK_C2316E125AF690F3` FOREIGN KEY (`gameCharacterId`) REFERENCES `GameCharacter` (`id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_C2316E122CDD71BB` FOREIGN KEY (`gameCharacterSourceId`) REFERENCES `GameCharacterSource` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `SignedForGameRole` (
    `id` CHAR(36) NOT NULL,
    `gameRole` TINYINT NOT NULL,
    `signUpId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_SignedForGameRole` PRIMARY KEY (`id`),
    CONSTRAINT `FK_16186B55A966702F` FOREIGN KEY (`signUpId`) REFERENCES `SignUp` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `Topic` (
    `id` CHAR(36) NOT NULL,
    `postDate` DATETIME NOT NULL,
    `subject` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `lastPostDate` DATETIME NULL,
    `forumId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `lastPostPosterId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
    `posterId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_Topic` PRIMARY KEY (`id`),
    CONSTRAINT `FK_5C81F11F22F0147C` FOREIGN KEY (`lastPostPosterId`) REFERENCES `User` (`id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_5C81F11F581A197` FOREIGN KEY (`posterId`) REFERENCES `User` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `Forum` (
    `id` CHAR(36) NOT NULL,
    `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `description` TEXT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `lastPostDate` DATETIME NULL,
    `lastPostPosterId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
    `lastPostTopicId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL,
    CONSTRAINT `PK_Forum` PRIMARY KEY (`id`),
    CONSTRAINT `FK_44EA91C922F0147C` FOREIGN KEY (`lastPostPosterId`) REFERENCES `User` (`id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_44EA91C91CA16452` FOREIGN KEY (`lastPostTopicId`) REFERENCES `Topic` (`id`) ON DELETE RESTRICT
);

CREATE TABLE `Post` (
    `id` CHAR(36) NOT NULL,
    `postDate` DATETIME NOT NULL,
    `content` LONGTEXT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `posterId` CHAR(36) NOT NULL COMMENT 'CHAR(36)',
    `topicId` CHAR(36) NOT NULL COMMENT 'CHAR(36)',
    CONSTRAINT `PK_Post` PRIMARY KEY (`id`),
    CONSTRAINT `FK_FAB8C3B3581A197` FOREIGN KEY (`posterId`) REFERENCES `User` (`id`) ON DELETE CASCADE,
    CONSTRAINT `FK_FAB8C3B3E2E0EAFB` FOREIGN KEY (`topicId`) REFERENCES `Topic` (`id`) ON DELETE CASCADE
);

CREATE TABLE `UnreadPost` (
    `id` CHAR(36) NOT NULL,
    `userId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    `postId` CHAR(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
    CONSTRAINT `PK_UnreadPost` PRIMARY KEY (`id`),
    CONSTRAINT `FK_6B0B9B3EE094D20D` FOREIGN KEY (`postId`) REFERENCES `Post` (`id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_6B0B9B3E62DEB3E8` FOREIGN KEY (`userId`) REFERENCES `User` (`id`) ON DELETE RESTRICT
);

CREATE INDEX `IDX_8A274BCA93C757EE` ON `ActivityQueueItem` (`activityById`);

CREATE INDEX `IDX_6E28848862DEB3E8` ON `CalendarExport` (`userId`);

CREATE INDEX `IDX_5BC96BF0ED8188B0` ON `Comment` (`groupId`);

CREATE INDEX `IDX_5BC96BF0581A197` ON `Comment` (`posterId`);

CREATE INDEX `IX_Event_commentGroupId` ON `Event` (`commentGroupId`);

CREATE INDEX `IDX_FA6F25A34BDD3C8` ON `Event` (`organiserId`);

CREATE INDEX `IDX_D25E05DD612E729E` ON `FeatureToggle` (`userId`);

CREATE INDEX `IDX_E504F432FCEF271C` ON `FeatureUse` (`usedById`);

CREATE INDEX `IDX_2B5F260E9DD8CB47` ON `Feedback` (`postedById`);

CREATE INDEX `IDX_44EA91C922F0147C` ON `Forum` (`lastPostPosterId`);

CREATE UNIQUE INDEX `IDX_44EA91C91CA16452` ON `Forum` (`lastPostTopicId`);

CREATE INDEX `IDX_F17408662DEB3E8` ON `ForumLastVisit` (`userId`);

CREATE INDEX `IDX_92AF3B34FA96DBDA` ON `GameCharacter` (`gameRealmId`);

CREATE INDEX `IDX_E115ED785AF690F3` ON `GameCharacterClaim` (`gameCharacterId`);

CREATE INDEX `IDX_E115ED7862DEB3E8` ON `GameCharacterClaim` (`userId`);

CREATE INDEX `IDX_C33F42E09113A92D` ON `GameCharacterClaimVersion` (`gameCharacterClaimId`);

CREATE INDEX `IDX_18BD775675407DAB` ON `GameCharacterSource` (`gameGuildId`);

CREATE INDEX `IDX_70D670C87D3656A4` ON `GameCharacterSource` (`userId`);

CREATE INDEX `IDX_EC73362CDD71BB` ON `GameCharacterSyncSession` (`gameCharacterSourceId`);

CREATE INDEX `IDX_A70EBD185AF690F3` ON `GameCharacterVersion` (`gameCharacterId`);

CREATE INDEX `IDX_A70EBD18F3B4E37B` ON `GameCharacterVersion` (`gameClassId`);

CREATE INDEX `IDX_A70EBD18E036C39A` ON `GameCharacterVersion` (`gameRaceId`);

CREATE INDEX `IDX_B48152AFFA96DBDA` ON `GameGuild` (`gameRealmId`);

CREATE INDEX `IDX_D51A7CF883048B90` ON `GameRace` (`gameFactionId`);

CREATE INDEX `IDX_CA2244C5AF690F3` ON `InGameGuild` (`gameCharacterId`);

CREATE INDEX `IDX_CA2244C75407DAB` ON `InGameGuild` (`gameGuildId`);

CREATE INDEX `IDX_C656D44393C757EE` ON `NotificationQueueItem` (`activityById`);

CREATE INDEX `IDX_7A9E9B239113A92D` ON `PlaysGameRole` (`gameCharacterClaimId`);

CREATE INDEX `IDX_FAB8C3B3581A197` ON `Post` (`posterId`);

CREATE INDEX `IDX_FAB8C3B3E2E0EAFB` ON `Post` (`topicId`);

CREATE INDEX `IDX_50C9810462DEB3E8` ON `Setting` (`userId`);

CREATE INDEX `IDX_16186B55A966702F` ON `SignedForGameRole` (`signUpId`);

CREATE INDEX `IDX_DC8B3F7B2B2EBB6C` ON `SignUp` (`eventId`);

CREATE INDEX `IDX_DC8B3F7B62DEB3E8` ON `SignUp` (`userId`);

CREATE INDEX `IDX_5C81F11F7830F151` ON `Topic` (`forumId`);

CREATE INDEX `IDX_5C81F11F22F0147C` ON `Topic` (`lastPostPosterId`);

CREATE INDEX `IDX_5C81F11F581A197` ON `Topic` (`posterId`);

CREATE INDEX `IDX_C2316E125AF690F3` ON `TrackedBy` (`gameCharacterId`);

CREATE INDEX `IDX_C2316E122CDD71BB` ON `TrackedBy` (`gameCharacterSourceId`);

CREATE INDEX `IDX_6B0B9B3EE094D20D` ON `UnreadPost` (`postId`);

CREATE INDEX `IDX_6B0B9B3E62DEB3E8` ON `UnreadPost` (`userId`);

CREATE UNIQUE INDEX `UNIQ_B28B6F38A0D96FBF` ON `User` (`displayName`);

CREATE UNIQUE INDEX `UNIQ_B28B6F3892FC23A8` ON `User` (`email`);

CREATE UNIQUE INDEX `UNIQ_B28B6F38C05FB297` ON `User` (`externalId`);

ALTER TABLE `Topic` ADD CONSTRAINT `FK_5C81F11F7830F151` FOREIGN KEY (`forumId`) REFERENCES `Forum` (`id`) ON DELETE CASCADE;
