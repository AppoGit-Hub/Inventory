import type { User } from '@auth0/auth0-angular';

export type AccessType = 'read' | 'write';
export type UserPermissions = `${AccessType}:${string}`;

export type UserModel = User & {
  permissions: UserPermissions[];
};
