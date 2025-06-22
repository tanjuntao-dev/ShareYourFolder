# ShareYourFolder

> A lightweight Windows utility for reliably accessing shared folders over unstable LAN connections.

---

## Overview

**ShareYourFolder** is a simple WinForms-based tool designed for internal use across home or team networks. It resolves the common issues associated with accessing network shares, especially in environments where:

- Devices get assigned dynamic IPs via DHCP
- Machines reside on different Wi-Fi subnets
- Hostname resolution fails due to router-level restrictions (mDNS, NetBIOS, LLMNR)
- Windows Explorer can't consistently open UNC paths via computer name

Instead of relying on fixed IPs or manual mapping, this tool automatically resolves hostnames to IP addresses, establishes the share connection via `net use`, and opens the folder with a single click.

---

## Features

-  Hostname to IPv4 resolution with ping verification
-  Credential-based login via `net use`
-  Direct UNC folder access in Explorer
-  Remembers last used input across sessions
-  Displays resolved IP for transparency
-  Graceful error handling with UI feedback

---

## Getting Started

1. Enter the following:
   - **Host Name** (e.g., `DESKTOP-ABC123`)
   - **Share Name** (e.g., `SharedDocs`)
   - **Username / Password**
2. Click **Connect**
3. If successful, the network share opens in a new Explorer window.

>  Ensure that file sharing is properly configured on the target machine and the user credentials have appropriate access rights.

---

## Download

Grab the latest `.zip` or `.exe` from the [Releases page](https://github.com/tanjuntao-dev/ShareYourFolder/releases). No installation required — just unzip and run.

---

## Roadmap

This utility is the first module of a planned toolchain tentatively named **Local Project Resource Explorer**, with the following future directions:

-  Project directory registration and tagging
-  Access timeline and audit logs
-  Role-based access control (read/write/restricted)
-  Scheduled backup and sync options
-  Frontend rework using modern UI frameworks (e.g., React + Electron)

---

## License

MIT License — see [`LICENSE`](./LICENSE) for details.

---

## Author

Tan Junto  
[github.com/tanjuntao-dev](https://github.com/tanjuntao-dev)
